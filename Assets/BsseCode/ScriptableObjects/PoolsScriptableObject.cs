using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BsseCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PoolPrefabsBase", menuName = "ScriptableObjects/PoolsScriptableObject")]
    public class PoolsScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public class PoolPrefabConfig
        {
            [Tooltip("Prefab for the pool.")]
            public GameObject Prefab;

            [Tooltip("Optional description for the prefab.")]
            public string Description;
        }


        [FormerlySerializedAs("PoolPrefabs")] [Tooltip("List of prefabs for pooling.")]
        public List<PoolPrefabConfig> ListOfPrefabs = new ();

        private void OnValidate()
        {
            foreach (var config in ListOfPrefabs)
            {
                if (config.Prefab == null || !config.Prefab)
                {
                    Debug.LogWarning($"A prefab in PoolPrefabs is not assigned or missing. Description: {config.Description ?? "No Description"}");
                }
            }
        }
    }
}