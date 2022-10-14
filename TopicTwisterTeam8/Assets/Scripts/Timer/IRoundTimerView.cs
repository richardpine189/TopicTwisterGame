using System;

public interface IRoundTimerView
{
    event Action<int> OnTimerStop;

    event Action OnTimerStart;
    public event Action OnTimerIsUp;

    void SetTimeLeft(int timeToAnswer);

    public void StopTimer();
}
