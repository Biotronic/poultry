using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Biotronic.Poultry.Utilities.Database.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.TraceSource;

namespace Biotronic.Poultry.Utilities.Database
{
    public abstract class BaseDbContext<TContext> : DbContext, IBaseDbContext where TContext : BaseDbContext<TContext>
    {
        protected BaseDbContext() { }

        protected BaseDbContext(DbContextOptions<TContext> options) : base(options) { }

        // ValueConverters to override default type mappings between C# and SQL Server.
        protected Dictionary<Type, ValueConverter> ValueConverters { get; } = new Dictionary<Type, ValueConverter>();

        // Name of column that is set to the current time when a row is created.
        protected string CreatedColumnName { get; set; } = "DbCreated";

        // Name of column that is updated automatically whenever a row is updated.
        protected string ChangedColumnName { get; set; } = "DbChanged";

        protected string ConnectionString { get; set; }

        protected ILoggerFactory Logger { get; set; } = new LoggerFactory(new[] { new TraceSourceLoggerProvider(new SourceSwitch("Trace")) });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);

            optionsBuilder.UseLoggerFactory(Logger);

            // Magically make queries faster!
            optionsBuilder.AddInterceptors(new SpeedInterceptor());

            // Always use bigint for TimeSpan columns.
            ValueConverters.Add(typeof(TimeSpan), new TimeSpanToTicksConverter());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var (clrType, entityType) in MappedTypes(modelBuilder))
            {
                foreach (var clrProperty in clrType.GetProperties())
                {
                    ApplyValueConverters(entityType, clrProperty);
                    ApplyAttributes(modelBuilder, clrType, entityType, clrProperty);
                }

                CreateMultiPartKey(clrType, entityType);
                AddDefaultColumns(entityType);
            }
        }

        private static void ApplyAttributes(ModelBuilder modelBuilder,
            Type clrType, EntityTypeBuilder entityType,
            PropertyInfo clrProperty)
        {
            PropertyBuilder entityProperty = null;
            foreach (var attribute in clrType.GetCustomAttributes<BaseAttribute>())
            {
                entityProperty ??= entityType.Property(clrProperty.Name);
                attribute.Apply(modelBuilder, clrType, entityType, clrProperty, entityProperty);
            }
        }

        private void ApplyValueConverters(EntityTypeBuilder entityType, PropertyInfo clrProperty)
        {
            foreach (var (type, converter) in ValueConverters)
            {
                if (clrProperty.PropertyType != type) continue;

                var entityProperty = entityType.Property(clrProperty.Name);
                Debug.Assert(clrProperty.ReflectedType != null);
                entityProperty.HasConversion(converter);
            }
        }

        private static void CreateMultiPartKey(Type clrType, EntityTypeBuilder entityType)
        {
            var keys = clrType.GetProperties()
                .Where(a => a.GetCustomAttribute<KeyAttribute>() != null)
                .Select(a => a.Name)
                .ToArray();
            if (keys.Length > 1)
            {
                entityType.HasKey(keys);
            }
        }

        // Add DbCreated and DbChanged columns automatically
        private void AddDefaultColumns(EntityTypeBuilder entityType)
        {
            entityType
                .Property(typeof(DateTime), CreatedColumnName)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            entityType
                .Property(typeof(DateTime), ChangedColumnName)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();
        }

        // The CLR types and respective entity types used by this DbContext.
        private IEnumerable<(Type, EntityTypeBuilder)> MappedTypes(ModelBuilder modelBuilder)
        {
            return GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .Where(a => a.PropertyType.IsGenericType)
                .Where(a => a.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(a => a.PropertyType.GenericTypeArguments[0])
                .OrderBy(a => a.Name)
                .Distinct()
                .Select(a => (a, modelBuilder.Entity(a)));
        }

        // Starts a batch operation, which will be completed when the BatchScope object is disposed.
        public BatchScope StartBatch()
        {
            return new BatchScope(this);
        }
    }
}