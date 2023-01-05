using System;
using UnityEngine;

namespace TypeSwitcher
{
    public abstract class SwitchableScriptableObject : ScriptableObject
    {
        [ContextMenu("Switch Type")]
        protected virtual void SwitchType()
        {
            new TypeDropdownMenu(GetType(), OnTypeSwitch, TypeSwitchSettings, sortItems: true)
                .ShowAsContext();
        }

        protected abstract TypeSwitchSettings TypeSwitchSettings { get; }

        protected virtual void OnTypeSwitch(Type type)
        {
            MonoScriptHelper.SwitchType(this, type);
        }
    }
}