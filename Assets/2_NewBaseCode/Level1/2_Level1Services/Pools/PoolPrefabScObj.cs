using System.Collections.Generic;
using UnityEngine;

namespace _2_NewBaseCode.Level1._2_Level1Services.Pools
{
    
    [CreateAssetMenu(fileName = "PoolPrefabScObj", menuName = "ScObj/PoolPrefabScObj")]
    public class PoolPrefabScObj : ScriptableObject
    {
        public List<GameObject> PoolPrefabs;
    }
}