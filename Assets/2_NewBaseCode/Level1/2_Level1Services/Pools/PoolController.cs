using System;
using System.Collections.Generic;
using _2_NewBaseCode.Level1._2_Level1Services.Factory;
using UnityEngine;
using Zenject;


namespace _2_NewBaseCode.Level1._2_Level1Services.Pools
{
    public class PoolController : MonoBehaviour, IPoolController
    {
        [SerializeField] private PoolPrefabScObj poolPrefabScObj; // Список префабов для пулов
        [SerializeField] private Transform poolParentContainer;  // Родительский объект для всех пулов

        private readonly Dictionary<Type, object> _poolsDictionary = new();
        private IFactory1 _factory1;

        [Inject]
        public void Construct(IFactory1 factory1)
        {
            _factory1 = factory1;
        }

        private void Start()
        {
            InitializePools();
        }

        /// <summary>
        /// Инициализация всех пулов из ScriptableObject.
        /// </summary>
        private void InitializePools()
        {
            if (poolPrefabScObj == null || poolPrefabScObj.PoolPrefabs == null || poolPrefabScObj.PoolPrefabs.Count == 0)
            {
                Debug.LogError("PoolPrefabScObj не задан или не содержит объектов.");
                return;
            }

            foreach (var poolPrefab in poolPrefabScObj.PoolPrefabs)
            {
                RegisterPool(poolPrefab);
            }
        }

        /// <summary>
        /// Регистрация пула для определенного префаба.
        /// </summary>
        private void RegisterPool(GameObject poolPrefab)
        {
            if (poolPrefab == null)
            {
                Debug.LogWarning("Пул не может быть зарегистрирован для null-префаба.");
                return;
            }

            var element = poolPrefab.GetComponent<IPoolsElement>();
            if (element == null)
            {
                Debug.LogWarning($"Префаб {poolPrefab.name} не реализует IPoolsElement.");
                return;
            }

            var elementType = element.GetType();
            if (_poolsDictionary.ContainsKey(elementType))
            {
                Debug.LogWarning($"Пул для типа {elementType} уже существует.");
                return;
            }

            _poolsDictionary[elementType] = CreatePool(poolPrefab, elementType);
        }

        /// <summary>
        /// Создание пула для заданного типа.
        /// </summary>
        private object CreatePool(GameObject poolPrefab, Type elementType)
        {
            var prefabComponent = poolPrefab.GetComponent(elementType) as Component;
            if (prefabComponent == null)
                throw new InvalidOperationException($"Префаб {poolPrefab.name} не содержит компонент {elementType}.");

            // Используем указанный poolParentContainer или создаём новый
            Transform poolContainer = poolParentContainer != null
                ? poolParentContainer
                : CreateDefaultPoolContainer();

            var poolType = typeof(PoolComponent<>).MakeGenericType(elementType);

            return Activator.CreateInstance(
                poolType,
                prefabComponent,
                25, // Начальный размер пула
                poolContainer,
                _factory1
            );
        }

        /// <summary>
        /// Создаёт контейнер по умолчанию, если poolParentContainer не указан.
        /// </summary>
        private Transform CreateDefaultPoolContainer()
        {
            var defaultContainer = new GameObject("DefaultPoolContainer").transform;
            defaultContainer.SetParent(transform);
            return defaultContainer;
        }

        /// <summary>
        /// Получение пула для заданного типа.
        /// </summary>
        public PoolComponent<T> GetPool<T>() where T : MonoBehaviour, IPoolsElement
        {
            var type = typeof(T);
            if (_poolsDictionary.TryGetValue(type, out var pool) && pool is PoolComponent<T> typedPool)
            {
                return typedPool;
            }

            Debug.LogWarning($"Пул для типа {type} не найден.");
            return null;
        }

        /// <summary>
        /// Возврат элемента в пул.
        /// </summary>
        public void ReturnToPool<T>(T element) where T : MonoBehaviour, IPoolsElement
        {
            if (element == null)
            {
                Debug.LogError("Невозможно вернуть null-элемент в пул.");
                return;
            }

            var pool = GetPool<T>();
            if (pool != null)
            {
                pool.ReturnToPool(element);
            }
            else
            {
                Debug.LogWarning($"Пул для типа {typeof(T)} не найден. Элемент не возвращён.");
            }
        }
    }

    public interface IPoolController
    {
        PoolComponent<T> GetPool<T>() where T : MonoBehaviour, IPoolsElement;
        void ReturnToPool<T>(T element) where T : MonoBehaviour, IPoolsElement;
    }
}
