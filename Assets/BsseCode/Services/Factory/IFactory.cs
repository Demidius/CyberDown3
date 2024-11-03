using UnityEngine;

namespace BsseCode.Services.Factory
{
    public interface IFactory<T> : IService
    {
        T Create(Vector2 position);
    }
}