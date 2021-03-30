using System;
using System.Linq;
using System.Reflection;

namespace Biotronic.Poultry.Utilities
{
    public static class ExtensionMethods
    {
        public static bool HasAttribute<TAttribute>(this MemberInfo member, Func<TAttribute, bool> predicate) where TAttribute : Attribute
        {
            return member.GetCustomAttributes<TAttribute>()
                .Any(predicate);
        }
    }
}
