using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biotronic.Poultry.Utilities.Database.Attributes
{
    public class ValueConverterAttribute : BaseAttribute
    {
        private readonly Type _converterType;

        public ValueConverterAttribute(Type converterType)
        {
            _converterType = converterType;
        }

        public override void Apply(ModelBuilder modelBuilder,
            Type clrType, EntityTypeBuilder entityType,
            PropertyInfo clrProperty, PropertyBuilder entityProperty)
        {
            entityProperty.HasConversion(_converterType);
        }
    }
}
