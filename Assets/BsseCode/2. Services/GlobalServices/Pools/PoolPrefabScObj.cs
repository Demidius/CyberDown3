using System.Collections.Generic;
using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.Pools
{
    
    [CreateAssetMenu(fileName = "PoolPrefabScObj", menuName = "ScObj/PoolPrefabScObj")]
    
    public class PoolPrefabScObj: ScriptableObject
    {
        public List<GameObject> PoolPrefabs;
    }
}