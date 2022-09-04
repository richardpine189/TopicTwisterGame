using System;

public interface IRoundTimerView
{
    event Action<int> OnTimerStop;

    event Action OnTimerStart;

    void SetTimeLeft(int timeToAnswer);

    public void StopTimer();
}
