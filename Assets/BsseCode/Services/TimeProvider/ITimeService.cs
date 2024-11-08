using System;

namespace BsseCode.Services.TimeProvider
{
    public interface ITimeService : IService
    {
        public event Action <float> ChangeTimeScale;
        float TimeScale { get; set; }
        float DeltaTime { get; }
    }
}