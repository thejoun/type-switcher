using UnityEngine;

namespace TypeSwitcher.Example
{
    [CreateAssetMenu(fileName = "Potion", menuName = "TypeSwitcher/Potion")]
    public class Potion : SwitchableScriptableObject
    {
        protected enum Size
        {
            Small,
            Medium,
            Big
        }

        [SerializeField] private Size size;
        
        protected override TypeSwitchSettings TypeSwitchSettings => new TypeSwitchSettings()
        {
            BaseType = typeof(Potion),      // select from all children of this class
            HideInPath = new[] { "Potion" } // remove this string from type names in the dropdown
        };
    }
}