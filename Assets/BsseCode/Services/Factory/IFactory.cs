using UnityEngine;

namespace BsseCode.Services.Factory
{
    public interface IFactory<T>
    {
        T Create(Vector2 position);
    }
}