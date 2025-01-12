using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.Factory
{
    public class FactoryComponent : IFactoryComponent
    {
        private DiContainer _container;

        public FactoryComponent(DiContainer container)
        {
            _container = container;
        }

        public T Create<T>(T prefab) where T : Component
        {
            return _container.InstantiatePrefab(prefab).GetComponent<T>();
        }

    }
}