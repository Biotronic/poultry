using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biotronic.Poultry.Utilities.Database.Attributes
{
    public class IndexAttribute : BaseAttribute
    {
        public string Name { get; set; }
        public bool Unique { get; set; } = true;

        public override void Apply(ModelBuilder modelBuilder,
            Type clrType, EntityTypeBuilder entityType,
            PropertyInfo clrProperty, PropertyBuilder entityProperty)
        {
            var properties = string.IsNullOrWhiteSpace(Name)
                ? new[] { clrProperty.Name }
                : clrType.GetProperties()
                    .Where(p => p.HasAttribute<IndexAttribute>(a => a.Name == Name))
                    .Select(p => p.Name)
                    .ToArray();

            Console.WriteLine($"{clrType.Name}: {clrProperty.Name} ({Name})");

            entityType.HasIndex(properties)
                .IsUnique(Unique);
        }
    }
}
