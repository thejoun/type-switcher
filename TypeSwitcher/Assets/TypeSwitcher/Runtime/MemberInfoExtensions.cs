using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TypeSwitcher
{
    public static class MemberInfoExtensions
    {
        public static IEnumerable<T> GetAttributes<T>(this MemberInfo provider) where T : Attribute
        {
            return provider.AllAttributes(typeof(T)).Cast<T>();
        }
    
        public static IEnumerable<Attribute> AllAttributes(this MemberInfo provider, params Type[] attributeTypes)
        {
            var allAttributes = Attribute.GetCustomAttributes(provider, typeof(Attribute), true);
        
            if (attributeTypes.Length == 0)
            {
                return allAttributes;
            }

            return allAttributes.Where(a => attributeTypes.Any(x => a.GetType().DerivesFromOrEqual(x)));
        }
    
        public static bool DerivesFromOrEqual(this Type a, Type b)
        {
            return b == a || b.IsAssignableFrom(a);
        }
    }
}
