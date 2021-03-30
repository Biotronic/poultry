using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biotronic.Poultry.Utilities.Database.Attributes
{
    public abstract class BaseAttribute : Attribute
    {
        public abstract void Apply(ModelBuilder modelBuilder,
            Type clrType, EntityTypeBuilder entityType,
            PropertyInfo clrProperty, PropertyBuilder entityProperty);
    }
}