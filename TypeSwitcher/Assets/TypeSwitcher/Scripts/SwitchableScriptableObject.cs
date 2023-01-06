using System;
using UnityEngine;

namespace TypeSwitcher
{
    public abstract class SwitchableScriptableObject<T> : SwitchableScriptableObject
    {
        protected override TypeSwitchSettings TypeSwitchSettings => new TypeSwitchSettings<T>();
    }
    
    public abstract class SwitchableScriptableObject : ScriptableObject
    {
        protected abstract TypeSwitchSettings TypeSwitchSettings { get; }

        [ContextMenu("Switch Type")]
        protected virtual void SwitchType()
        {
            TypeDropdownMenu.Create(GetType(), OnTypeSwitch, TypeSwitchSettings).ShowAsContext();
        }

        protected virtual void OnTypeSwitch(Type type)
        {
            MonoScriptHelper.SwitchType(this, type);
        }
    }
}