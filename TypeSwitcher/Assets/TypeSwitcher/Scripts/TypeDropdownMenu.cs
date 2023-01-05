using System;
using System.Linq;
using UnityDropdown.Editor;

namespace TypeSwitcher
{
    public class TypeDropdownMenu
    {
        private DropdownMenu<Type> _dropdown;
        private TypeSwitchSettings _settings;

        public TypeDropdownMenu(Type currentType, Action<Type> callback, 
            TypeSwitchSettings settings = null, 
            int searchbarMinItemsCount = 10, bool sortItems = false, bool showNoneElement = false)
        {
            _settings = settings ?? new TypeSwitchSettings();

            var baseType = _settings.BaseType;
            var excludeBaseType = _settings.ExcludeBaseType;
            
            var typeList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(domainAssembly => domainAssembly.GetTypes())
                .Where(type => baseType.IsAssignableFrom(type) 
                               && !type.IsAbstract 
                               && (!excludeBaseType || type != _settings.BaseType));

            var items = typeList
                .Select(type => new DropdownItem<Type>(type, _settings.GetTypePath(type), 
                    searchName: _settings.GetTypeName(type)))
                .ToList();

            var currentItem = items.FirstOrDefault(item => item.Value == currentType);

            if (currentItem != default)
            {
                currentItem.IsSelected = true;
            }

            var dropdownMenu = new DropdownMenu<Type>(items, callback, searchbarMinItemsCount, sortItems, 
                showNoneElement);

            _dropdown = dropdownMenu;
        }

        public void ShowAsContext()
        {
            _dropdown.ShowAsContext();
        }
    }
}