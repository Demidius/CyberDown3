using System;
using System.Collections.Generic;
using UnityEngine;

namespace BsseCode._2._Services.UpdateManeger
{
    public class UpdateManeger : MonoBehaviour, IUpdateManeger
    {
        private readonly List<Action> _methods = new List<Action>();

        public void AddMethod(Action method) => _methods.Add(method);

        public void LogMethodNames()
        {
            foreach (var method in _methods)
            {
                Console.WriteLine($"Метод: {method.Method.Name}");
            }
        }

        public void Update()
        {
            foreach (var method in _methods)
            {
                try
                {
                    method();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в методе '{method.Method.Name}': {ex.Message}");
                }
            }
        }
    }

    public interface IUpdateManeger
    {
        void AddMethod(Action method);
        void LogMethodNames();
    }
}