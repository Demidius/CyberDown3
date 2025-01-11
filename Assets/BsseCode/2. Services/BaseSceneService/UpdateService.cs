using System;
using System.Collections.Generic;
using UnityEngine;

namespace BsseCode._2._Services.BaseSceneService
{
    public class UpdateService : MonoBehaviour, IUpdateService
    {
       
        private readonly List<Action> _methods = new List<Action>();
      
        public void RegisterMethod(Action method)
        {
            if (method == null)
            {
                Debug.LogError("Попытка добавить null метод в UpdateManeger");
                return;
            }

            _methods.Add(method);
        }

        public bool UnregisterMethod(Action method)
        {
            if (method == null)
            {
                Debug.LogError("Попытка удалить null-метод из UpdateManeger");
                return false;
            }

            if (_methods.Contains(method))
            {
                _methods.Remove(method);
                Debug.Log($"Метод [{method.Method.Name}] удалён из UpdateManeger");
                return true;
            }
            else
            {
                Debug.LogWarning($"Метод [{method.Method.Name}] не найден в списке");
                return false;
            }
        }

        public void UpdateAllMethods()
        {
            foreach (var method in _methods)
            {
                try
                {
                    method.Invoke();
                }
                catch (Exception ex)
                {
                    Debug.LogError(
                        $"Ошибка при выполнении метода [{method.Method.Name}]: {ex.Message}\n{ex.StackTrace}"
                    );
                }
            }
        }
      
        public void LogAllMethodNames()
        {
            if (_methods.Count == 0)
            {
                Debug.Log("Список методов пуст.");
                return;
            }

            Debug.Log("Список имен зарегистрированных методов:");
            foreach (var method in _methods)
            {
                Debug.Log(method.Method.Name);
            }
        }
       
        private void Update()
        {
            UpdateAllMethods();
        }
    }

    public interface IUpdateService
    {
        void RegisterMethod(Action method);
        public bool UnregisterMethod(Action method);
        void LogAllMethodNames();
    }
}