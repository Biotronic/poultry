using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Biotronic.Poultry.Utilities
{
    public static class ExtensionMethods
    {
        public static bool HasAttribute<TAttribute>(this MemberInfo member, Func<TAttribute, bool> predicate) where TAttribute : Attribute
        {
            return member.GetCustomAttributes<TAttribute>()
                .Any(predicate);
        }

        public static bool IsGenericInstanceOf(this Type type, Type generic)
        {
            Debug.Assert(generic.IsGenericType, "IsGenericInstanceOf expects one instantiated and one non-instantiated Type.");
            if (!type.IsGenericType) return false;
            return type.GetGenericTypeDefinition() == generic;
        }

        public static MethodInfo GetMethod(this Type type, Func<MethodInfo, bool> filter)
        {
            return type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Where(filter).FirstOrDefault();
        }

        public static bool Matches(this MethodInfo method, string name, bool? isGeneric = null, params Type[] parameterTypes)
        {
            if (method.Name != name) return false;
            if (isGeneric.HasValue && method.IsGenericMethod != isGeneric) return false;
            if (parameterTypes == null) return true;
            if (method.GetParameters().Length != parameterTypes.Length) return false;
            return method.GetParameters().Zip(parameterTypes).All(a => a.First.ParameterType == a.Second || !a.Second.IsConstructedGenericType && a.First.ParameterType.IsGenericInstanceOf(a.Second));
        }

        public static Type GetMemberType(this MemberInfo member)
        {
            if (member is FieldInfo field)
            {
                return field.FieldType;
            }

            if (member is PropertyInfo property)
            {
                return property.PropertyType;
            }

            if (member is MethodInfo method)
            {
                return method.ReturnType;
            }

            Debug.Assert(false, $"MemberInfo {member} is of unexpected type {member.GetType()}");
            return null;
        }

        public static TFunc DynamicCall<TFunc>(this object context, MethodInfo method, params object[] args)
        {
            return Expression.Lambda<TFunc>(Expression.Call(Expression.Constant(context), method)).Compile();
        }
    }
}
