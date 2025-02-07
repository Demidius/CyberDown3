using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1._2_Level1Services.Factory
{
    public class Factory1 : IFactory1
    {
        private readonly DiContainer _container;

        public Factory1(DiContainer container)
        {
            _container = container;
        }

        public T Create<T>(T prefab) where T : Component
        {
            return _container.InstantiatePrefab(prefab).GetComponent<T>();
        }
    }
}