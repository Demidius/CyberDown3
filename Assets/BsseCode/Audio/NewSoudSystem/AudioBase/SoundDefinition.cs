using System;
using UnityEditor;
using UnityEngine;

namespace BsseCode.Audio.NewSoudSystem.AudioBase
{
    [CreateAssetMenu(menuName = "Datebase/Sound")]
    public class SoundDefinition : ScriptableObject
    {
        public int Id;
        public string Name;
        public FloatParameterDefinition[] FloatParameters;

        [Serializable]
        public class FloatParameterDefinition
        {
            public string Name;
            public float DefaultValue;
        }
    }
}