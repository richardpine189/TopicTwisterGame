namespace Architecture.Timer
{
    public interface IRoundTimerUseCase
    {
        int GetTimeToAnswer();

        void SaveTimeToRound(int timeLeft);
    }
}
