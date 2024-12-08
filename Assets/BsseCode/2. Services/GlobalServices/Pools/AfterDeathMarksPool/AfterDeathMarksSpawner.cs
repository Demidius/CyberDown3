using BsseCode._5._GameEntities.Objects.AfterDeathMarks;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.Pools.AfterDeathMarksPool
{
    public class AfterDeathMarksSpawner : MonoBehaviour
    {

        private Transform _spawnPoint;
        private IPoolController _poolController;


        [Inject]
        public void Construct(IPoolController poolController)
        {
            _poolController = poolController;
        }


        public void Spawn(Vector2 position)
        {
            var element = _poolController.GetPool<AfterDeathMarks>().GetElement();
            element.transform.position = position;
        }
    }

}