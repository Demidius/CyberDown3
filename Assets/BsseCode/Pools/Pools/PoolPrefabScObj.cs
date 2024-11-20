using System;
using System.Collections.Generic;
using UnityEngine;

namespace BsseCode.Pools.Pools
{
    
    [CreateAssetMenu(fileName = "PoolPrefabScObj", menuName = "ScObj/PoolPrefabScObj")]
    
    public class PoolPrefabScObj: ScriptableObject
    {
        public List<GameObject> PoolPrefabs;
    }
}