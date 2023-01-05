#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TypeSwitcher
{
    public static class MonoScriptHelper
    {
        public static void SwitchType(MonoBehaviour instance, Type type)
        {
            var monoScript = GetMonoScript(type);
            ChangeMonoScript(instance, monoScript);
        }
        
        public static void SwitchType(ScriptableObject instance, Type type)
        {
            var monoScript = GetMonoScript(type);
            ChangeMonoScript(instance, monoScript);
        }

        public static MonoScript GetMonoScript(Type type)
        {
            if (typeof(MonoBehaviour).IsAssignableFrom(type))
            {
                var go = new GameObject("GetMonoScript temporary GameObject");
                var component = go.AddComponent(type) as MonoBehaviour;
                var monoScript = MonoScript.FromMonoBehaviour(component);
            
                Object.DestroyImmediate(go);

                return monoScript;
            }
            
            if (typeof(ScriptableObject).IsAssignableFrom(type))
            {
                var scriptableObject = ScriptableObject.CreateInstance(type);
                var monoScript = MonoScript.FromScriptableObject(scriptableObject);

                Object.DestroyImmediate(scriptableObject);
                
                return monoScript;
            }
            
            Debug.LogError($"Can't get MonoScript of type '{type.Name}' " +
                           $"- it's neither a MonoBehaviour or ScriptableObject.");
            return default;
        }

        public static void ChangeMonoScript(Object instance, MonoScript script)
        {
#if UNITY_EDITOR
            var so = new SerializedObject(instance);
            var scriptProperty = so.FindProperty("m_Script");
            
            so.Update();
            scriptProperty.objectReferenceValue = script;
            so.ApplyModifiedProperties();
#endif
        }
    }
}