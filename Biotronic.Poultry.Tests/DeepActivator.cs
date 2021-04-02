using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Tests
{
    public static class DeepActivator
    {
        private static bool IsListType(Type type) => typeof(IList).IsAssignableFrom(type);

        private static void FillList(IList lst, Type t, IDictionary<Type, object> instances)
        {
            var elementType = t.GetElementType() ?? t.GenericTypeArguments[0];
            var element = CreateObject(elementType, instances);
            if (t.IsArray) lst[0] = element;
            else lst.Add(element);
        }

        public static T CreateInstance<T>()
        {
            var t = typeof(T);
            if (GlobalInstances.ContainsKey(t))
            {
                return (T)GlobalInstances[t];
            }

            return (T)CreateObject(t, new Dictionary<Type, object>());
        }

        static DeepActivator()
        {
            Reset();
        }

        public static void Reset()
        {
            GlobalInstances.Clear();
            GlobalMembers.Clear();
            GlobalNames.Clear();
            GlobalFactories.Clear();

            Register<byte>(1);
            Register<sbyte>(1);
            Register<short>(1);
            Register<ushort>(1);
            Register<int>(1);
            Register<uint>(1);
            Register<long>(1);
            Register<ulong>(1);
            Register<float>(1.0f);
            Register<double>(1.0);
            Register("Foo");
            Register(Guid.Empty);
            Register(new DateTime(2020, 1, 1));
        }

        private static object CreateObject(Type t, IDictionary<Type, object> instances)
        {
            if (instances.TryGetValue(t, out var existing) ||
                GlobalInstances.TryGetValue(t, out existing))
            {
                return existing;
            }

            if (t.IsInterface)
            {
                if (t.IsGenericType && (t.GetGenericTypeDefinition() == typeof(IList<>) || t.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                {
                    var result = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(t.GenericTypeArguments), 1);
                    instances[t] = result;
                    FillList(result, t, instances);
                    return result;
                }
                Debug.Assert(false, $"Can't create instance of interface {t}");
            }

            if (IsListType(t))
            {
                var result = (IList)Activator.CreateInstance(t, 1);
                instances[t] = result;
                FillList(result, t, instances);
                return result;
            }

            if (t.IsClass || (t.IsValueType && !t.IsEnum))
            {
                var ctors = t.GetConstructors().OrderBy(a => a.GetParameters().Length).ToList();

                object result = null;
                if (ctors.Any())
                {
                    var parameters = ctors[0].GetParameters().Select(a => CreateObject(a.ParameterType, instances)).ToArray();
                    result = Activator.CreateInstance(t, parameters);
                }
                else if (GlobalFactories.TryGetValue(t, out var factory))
                {
                    result = factory();
                }
                else
                {
                    result = Activator.CreateInstance(t);
                    Debug.Assert(result != null, $"Unable to create instance of {t}");
                }

                instances[t] = result;
                foreach (var property in t.GetProperties())
                {
                    if (GlobalMembers.TryGetValue(Tuple.Create(property.DeclaringType, property.PropertyType, property.Name), out var value))
                    {
                        property.SetValue(result, value);
                    }
                    else if (property.SetMethod != null)
                    {
                        property.SetValue(result,
                            GlobalNames.TryGetValue((property.Name, property.PropertyType), out value)
                                ? value
                                : CreateObject(property.PropertyType, instances));
                    }
                    else if (IsListType(property.PropertyType))
                    {
                        var lst = (IList)property.GetValue(result);
                        FillList(lst, property.PropertyType, instances);
                    }
                }

                return result;
            }

            return instances[t] = Activator.CreateInstance(t);
        }


        private static readonly Dictionary<Type, object> GlobalInstances = new Dictionary<Type, object>();
        private static Dictionary<Tuple<Type, Type, string>, object> GlobalMembers { get; } = new Dictionary<Tuple<Type, Type, string>, object>();
        private static Dictionary<(string, Type), object> GlobalNames { get; } = new Dictionary<(string, Type), object>();
        private static Dictionary<Type, Func<object>> GlobalFactories { get; } = new Dictionary<Type, Func<object>>();

        public static void Register<T, TMember>(Expression<Func<T, TMember>> memberSelector, TMember value)
        {
            var body = memberSelector.Body as MemberExpression;
            GlobalMembers[Tuple.Create(body.Member.DeclaringType, body.Member.GetMemberType(), body.Member.Name)] = value;
        }

        public static void Register<T>(T value)
        {
            GlobalInstances[typeof(T)] = value;
        }

        public static void Register<T>(string propertyName, T value)
        {
            GlobalNames[(propertyName, typeof(T))] = value;
        }

        public static void Register<T>(Func<T> factory)
        {
            GlobalFactories[typeof(T)] = () => factory;
        }

        public static void Unregister<T, TMember>(Expression<Func<T, TMember>> memberSelector)
        {
            var body = memberSelector.Body as MemberExpression;
            GlobalMembers.Remove(Tuple.Create(body.Member.DeclaringType, body.Member.GetMemberType(), body.Member.Name));
        }

        public static void Unregister<T>()
        {
            GlobalInstances.Remove(typeof(T));
        }

        public static void Unregister<T>(string propertyName)
        {
            GlobalNames.Remove((propertyName, typeof(T)));
        }

        public static void Unregister<T>(Func<T> factory)
        {
            GlobalFactories.Remove(typeof(T));
        }
    }
}