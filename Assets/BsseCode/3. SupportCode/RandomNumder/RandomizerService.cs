using System;

namespace BsseCode._3._SupportCode.RandomNumder
{
    public class RandomizerService : IRandomizerService
    {
        public T GetRandomValue<T>(T min, T max)
        {
            Type type = typeof(T);

            if (type == typeof(int))
            {
                int minValue = Convert.ToInt32(min);
                int maxValue = Convert.ToInt32(max);
                int randomValue = UnityEngine.Random.Range(minValue, maxValue);
                return (T)Convert.ChangeType(randomValue, type);
            }
            else if (type == typeof(float))
            {
                float minValue = Convert.ToSingle(min);
                float maxValue = Convert.ToSingle(max);
                float randomValue = UnityEngine.Random.Range(minValue, maxValue);
                return (T)Convert.ChangeType(randomValue, type);
            }
            else
            {
                throw new NotSupportedException($"Тип {type} не поддерживается");
            }
        }
    }
}