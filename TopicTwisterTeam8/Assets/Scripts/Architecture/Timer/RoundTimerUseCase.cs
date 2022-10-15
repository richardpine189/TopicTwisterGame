using Architecture.Match.UseCases.GetRoundData;
using Architecture.Match.UseCases.SaveRoundData;

namespace Architecture.Timer
{
    public class RoundTimerUseCase : IRoundTimerUseCase
    {

        private readonly IGetRoundDataUseCase _getRoundDataUseCase;
        private readonly ISaveRoundDataUseCase _saveRoundDataUseCase;

        private const int EXTRA_TIME = 10;

        private const int DEFAULT_TIME = 60;
        //TODO : Ver si es necesario separarlo en dos useCase

        public RoundTimerUseCase(IGetRoundDataUseCase getRoundDataUseCase, ISaveRoundDataUseCase saveRoundDataUseCase)
        {
            _getRoundDataUseCase = getRoundDataUseCase;
            _saveRoundDataUseCase = saveRoundDataUseCase;
        }

        public void SaveTimeToRound(int timeLeft)
        {
            int tempTime = DEFAULT_TIME - timeLeft;
            _saveRoundDataUseCase.SaveCurrentTime(tempTime);
        }

        public int GetTimeToAnswer()
        {
            int timeLeft = _getRoundDataUseCase.GetCurrentTime();

            return timeLeft < EXTRA_TIME ? timeLeft + EXTRA_TIME : timeLeft;
        }
    }
}
