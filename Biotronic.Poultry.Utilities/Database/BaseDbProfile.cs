using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;

namespace Biotronic.Poultry.Utilities.Database
{
    public abstract class BaseDbProfile<TContext> : Profile where TContext : DbContext, IBaseDbContext
    {
        private TContext Context { get; }

        protected BaseDbProfile(TContext context, Assembly dtoAssembly)
        {
            Context = context;

            var dbTypes = Context.GetType().GetProperties()
                .Where(a => a.PropertyType.IsGenericInstanceOf(typeof(DbSet<>)))
                .Select(a => a.PropertyType.GenericTypeArguments[0])
                .ToList();
            var dtoTypes = dtoAssembly.ExportedTypes
                .Where(a => a.BaseType == typeof(BaseDtoObject))
                .ToDictionary(a => a.Name, a => a);

            foreach (var dbType in dbTypes)
            {
                Debug.Assert(dbType.BaseType == typeof(BaseDbObject), $"{dbType} must be a subtype of {typeof(BaseDbObject)}");

                var dtoType = dtoTypes[dbType.Name];
                CreateDefaultMap(dtoType, dbType);
            }
        }

        private void CreateDefaultMap(Type sourceType, Type destinationType)
        {
            Debug.Assert(sourceType.IsSubclassOf(typeof(BaseDtoObject)));
            Debug.Assert(destinationType.IsSubclassOf(typeof(BaseDbObject)));

            var targetFunc = typeof(BaseDbProfile<TContext>)
                .GetDeclaredMethod(nameof(CreateDefaultMapImpl))
                .MakeGenericMethod(sourceType, destinationType);

            this.DynamicCall<System.Action>(targetFunc)();
        }

        private void CreateDefaultMapImpl<TSource, TDestination>() where TSource : BaseDtoObject where TDestination : BaseDbObject
        {
            CreateMap<TSource, TDestination>()
                .ConstructUsing(Instantiate<TSource, TDestination>)
                .ForAllMembers(expression =>
                {
                    expression.Condition(src => src.Action != Action.None &&
                                                ((src.Changes?.Contains(expression.DestinationMember.Name) ?? true) || src.Action == Action.Create));
                });
        }

        private TDestination Instantiate<TSource, TDestination>(TSource source, ResolutionContext context) where TSource : BaseDtoObject where TDestination : BaseDbObject
        {
            if (source.Action == Action.Create)
            {
                Debug.Assert(source.Id == 0, "When creating a new object, its Id field must be 0.");
                return Context.Add(Activator.CreateInstance<TDestination>()).Entity;
            }

            Debug.Assert(source.Id != 0, "When referencing an existing object, its Id field must not be 0.");

            var result = Context.Find<TDestination>(source.Id);
            if (source.Action == Action.Delete)
            {
                Context.Remove(result);
            }

            return result;
        }
    }
}