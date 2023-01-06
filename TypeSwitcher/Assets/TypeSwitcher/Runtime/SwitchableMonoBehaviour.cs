using System;
using UnityEngine;
#if UNITY_EDITOR
using TypeSwitcher.Editor;
#endif

namespace TypeSwitcher
{
    public abstract class SwitchableMonoBehaviour<T> : SwitchableMonoBehaviour
    {
        protected override TypeSwitchSettings TypeSwitchSettings => new TypeSwitchSettings<T>();
    }
    
    public abstract class SwitchableMonoBehaviour : MonoBehaviour
    {
        protected abstract TypeSwitchSettings TypeSwitchSettings { get; }

#if UNITY_EDITOR
        [ContextMenu("Switch Type")]
        protected virtual void SwitchType()
        {
            TypeDropdownMenu.Create(GetType(), OnTypeSwitch, TypeSwitchSettings).ShowAsContext();
        }

        protected virtual void OnTypeSwitch(Type type)
        {
            MonoScriptHelper.SwitchType(this, type);
        }
#endif
    }
}