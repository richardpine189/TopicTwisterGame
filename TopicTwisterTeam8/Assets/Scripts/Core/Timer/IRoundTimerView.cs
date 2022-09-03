using System;

public interface IRoundTimerView
{
    event Action<int> OnTimerStop;

    void SetTimeLeft(int timeToAnswer);

    public void StopTimer();
}
