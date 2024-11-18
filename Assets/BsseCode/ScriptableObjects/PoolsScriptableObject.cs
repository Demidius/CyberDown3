using System.Collections.Generic;
using UnityEngine;

namespace BsseCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PoolPrefabsBase", menuName = "ScriptableObjects/PoolsScriptableObject")]
    public class PoolsScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public class PoolPrefabConfig
        {
            [Tooltip("Prefab for the pool.")]
            public MonoBehaviour Prefab;

            [Tooltip("Optional description for the prefab.")]
            public string Description;
        }

        [Tooltip("List of prefabs for pooling.")]
        public List<PoolPrefabConfig> PoolPrefabs = new List<PoolPrefabConfig>();

        private void OnValidate()
        {
            foreach (var config in PoolPrefabs)
            {
                if (config.Prefab == null)
                {
                    Debug.LogWarning($"A prefab in PoolPrefabs is not assigned. Description: {config.Description}");
                }
            }
        }
    }
}