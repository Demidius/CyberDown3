using System;

namespace BsseCode.Services.TimeProvider
{
    public interface ITimeService : IService
    {
        event Action ChangeTimeScale;
        float TimeScale { get; set; }
        float DeltaTime { get; }
    }
}