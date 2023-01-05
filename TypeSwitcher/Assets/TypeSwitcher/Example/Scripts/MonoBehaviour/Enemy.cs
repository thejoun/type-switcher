using UnityEngine;

namespace TypeSwitcher.Example
{
    public abstract class Enemy : SwitchableMonoBehaviour
    {
        [Header("Enemy")]
        [SerializeField] private float hitpoints;
    
        protected override TypeSwitchSettings TypeSwitchSettings => new TypeSwitchSettings()
        {
            BaseType = typeof(Enemy),    // select from all children of this class
            HideInPath = new []{"Enemy"} // remove this string from type names in the dropdown
        };
    }
}