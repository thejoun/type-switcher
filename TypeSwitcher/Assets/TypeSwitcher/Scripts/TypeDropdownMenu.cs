using System;
using System.Linq;
using UnityDropdown.Editor;

namespace TypeSwitcher
{
    public static class TypeDropdownMenu
    {
        public static DropdownMenu<Type> Create(Type currentType, Action<Type> callback, TypeSwitchSettings settings)
        {
            var baseType = settings.BaseType;
            var includeBaseType = settings.IncludeBaseType;

            var typeList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(domainAssembly => domainAssembly.GetTypes())
                .Where(type => baseType.IsAssignableFrom(type)
                               && !type.IsAbstract
                               && (includeBaseType || type != settings.BaseType));

            var items = typeList
                .Select(type => new DropdownItem<Type>(type, settings.GetTypePath(type),
                    searchName: settings.GetTypeName(type)))
                .ToList();

            var currentItem = items.FirstOrDefault(item => item.Value == currentType);

            if (currentItem != default)
            {
                currentItem.IsSelected = true;
            }

            var dropdownMenu = new DropdownMenu<Type>(items, callback, 10, true);
            
            return dropdownMenu;
        }
    }
}