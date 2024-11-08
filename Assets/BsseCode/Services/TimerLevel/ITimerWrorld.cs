namespace BsseCode.Services.TimerLevel
{
    public interface ITimerWrorld
    {
        public float CurrentTimerValue { get; set; }
        public string CurrentTimeOnString { get; set; }
        public void StartTimer();
        public void ResetTimer();
        public void StopTimer();
    }
}