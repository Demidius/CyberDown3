using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.Factory
{
    public interface IFactory<T> : IGlobalService
    {
        T Create(Vector2 position);
    }
}