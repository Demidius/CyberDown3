using UnityEngine;

namespace BsseCode.Services.Factory
{
    public interface IFactoryComponent
    {
        T Create<T>(T prefab) where T : Component;
    }
}