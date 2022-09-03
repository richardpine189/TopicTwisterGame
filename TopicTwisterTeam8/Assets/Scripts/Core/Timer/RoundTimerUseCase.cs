using Zenject;

public class RoundTimerUseCase : IRoundTimerUseCase
{
    private IActiveMatch _activeMatch;

    public RoundTimerUseCase(IActiveMatch activeMatch)
    {
        _activeMatch = activeMatch;
    }

    public void SaveTimeToRound(int timeLeft)
    {
        _activeMatch.Match.roundTimeLeft = 60 - timeLeft;
    }

    public int GetTimeToAnswer()
    {
        int timeLeft = _activeMatch.Match.roundTimeLeft;

        if (timeLeft < 10)
        {
            return timeLeft + 10;
        }

        return timeLeft;
    }
}
