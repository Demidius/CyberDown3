using System;

namespace BsseCode._2._Services.GlobalServices.TimeProvider
{
    public interface ITimeGlobalService : IGlobalService
    {
        public event Action <float> ChangeTimeScale;
        float TimeScale { get; set; }
        float DeltaTime { get; }
        public void ResetTimeScale();
    }
}