namespace BsseCode.Services.RandomNumder
{
    public interface IRandomizerService
    {
        T GetRandomValue<T>(T min, T max);
    }
}