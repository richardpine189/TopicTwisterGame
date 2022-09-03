public interface IRoundTimerUseCase
{
    int GetTimeToAnswer();

    void SaveTimeToRound(int timeLeft);
}
