using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.Factory
{
    public interface IFactoryComponent
    {
        T Create<T>(T prefab) where T : Component;
    }
}