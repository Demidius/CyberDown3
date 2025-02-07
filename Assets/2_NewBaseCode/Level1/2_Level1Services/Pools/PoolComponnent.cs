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
        private readonly IFactory1 _factory1;

        public PoolComponent(T prefab, int count, Transform container, IFactory1 factory1)
        {
            PrefabObject = prefab;
            Container = container;
            _factory1 = factory1;

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
            var createdObject = _factory1.Create(PrefabObject);
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