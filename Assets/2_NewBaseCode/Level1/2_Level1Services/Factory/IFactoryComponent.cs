using UnityEngine;

namespace _2_NewBaseCode.Level1._2_Level1Services.Factory
{
    public interface IFactoryComponent
    {
        T Create<T>(T prefab) where T : Component;
    }
}