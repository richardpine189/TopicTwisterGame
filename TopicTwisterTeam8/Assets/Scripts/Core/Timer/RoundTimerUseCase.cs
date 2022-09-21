using Zenject;

public class RoundTimerUseCase : IRoundTimerUseCase
{

    private readonly IGetRoundData _getRoundData;
    private readonly ISaveRoundData _saveRoundData;

    private const int EXTRA_TIME = 10;

    private const int DEFAULT_TIME = 60;
    //TODO : Ver si es necesario separarlo en dos useCase

    public RoundTimerUseCase(IGetRoundData getRoundData, ISaveRoundData saveRoundData)
    {
        _getRoundData = getRoundData;
        _saveRoundData = saveRoundData;
    }

    public void SaveTimeToRound(int timeLeft)
    {
        int tempTime = DEFAULT_TIME - timeLeft;
        _saveRoundData.SaveCurrentTime(tempTime);
    }

    public int GetTimeToAnswer()
    {
        int timeLeft = _getRoundData.GetCurrentTime();

        return timeLeft < EXTRA_TIME ? timeLeft + EXTRA_TIME : timeLeft;
    }
}
