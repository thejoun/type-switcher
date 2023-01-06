using System;
using UnityEngine;

namespace TypeSwitcher
{
    public abstract class SwitchableMonoBehaviour<T> : SwitchableMonoBehaviour
    {
        protected override TypeSwitchSettings TypeSwitchSettings => new TypeSwitchSettings<T>();
    }
    
    public abstract class SwitchableMonoBehaviour : MonoBehaviour
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