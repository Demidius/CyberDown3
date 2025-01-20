using System.Collections.Generic;
using _2_NewBaseCode.Level1._2_Level1Services.Factory;
using UnityEngine;

namespace _2_NewBaseCode.Level1._2_Level1Services.Pools
{
    public class PoolComponent<T> where T : Component
    {
        public T PrefabObject { get; }
        public Transform Container { get; }

        private readonly Queue<T> pool = new();
        private readonly IFactoryComponent _factoryComponent;

        public PoolComponent(T prefab, int count, Transform container, IFactoryComponent factoryComponent)
        {
            PrefabObject = prefab;
            Container = container;
            _factoryComponent = factoryComponent;

            Instantiate(count);
        }

        public void ReturnToPool(T element)
        {
            element.gameObject.SetActive(false);
            pool.Enqueue(element);
        }

        public T GetOrCreate()
        {
            return pool.Count > 0 ? ActivateObject(pool.Dequeue()) : CreateComponent();
        }

        private void Instantiate(int count)
        {
            for (int i = 0; i < count; i++)
            {
                pool.Enqueue(CreateComponent());
            }
        }

        private T CreateComponent()
        {
            var createdObject = _factoryComponent.Create(PrefabObject);
            createdObject.transform.SetParent(Container);
            createdObject.gameObject.SetActive(false);
            return createdObject;
        }

        private T ActivateObject(T obj)
        {
            obj.gameObject.SetActive(true);
            return obj;
        }
    }
    
    
}