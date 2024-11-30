using System;
using UnityEditor;
using UnityEngine;

namespace BsseCode.Audio.NewSoudSystem
{
    public class ReadOnlyInInspectorAttribute : Attribute
    {
#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(ReadOnlyInInspectorAttribute))]
        public class ReadOnlyDrawer : PropertyDrawer
        {
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                GUI.enabled = false;
                EditorGUI.PropertyField(position, property, label, true);
                GUI.enabled = true;
            }
        }
#endif
    }
}