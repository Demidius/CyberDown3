namespace BsseCode._3._SupportCode.RandomNumder
{
    public interface IRandomizerService
    {
        T GetRandomValue<T>(T min, T max);
    }
}