namespace BsseCode._2._Services.LevelServices.TimerLevel
{
    public interface ITimerLevel
    {
        public float CurrentTimerValue { get; set; }
        public string CurrentTimeOnString { get; set; }
        public void StartTimer();
        public void ResetTimer();
        public void StopTimer();
    }
}