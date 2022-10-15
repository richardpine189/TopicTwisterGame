using Architecture.Match.ActiveMatchRepository;
using Zenject;

namespace Architecture.Match.UseCases.GetRoundData
{
    class GetRoundData : IGetRoundDataUseCase
    {
        [Inject] private IActiveMatchRepository _activeMatchRepository;

        public string[] GetCurrentCategories()
        {
            return _activeMatchRepository.Match.round.CurrentCategories;
        }

        public char? GetCurrentLetter()
        {
            return _activeMatchRepository.Match.round.CurrentLetter;
        }

        public string[] GetCurrentAnswers()
        {
            return _activeMatchRepository.Match.round.CurrentAnswers;
        }

        public bool[] GetCurrentResults()
        {
            return _activeMatchRepository.Match.round.CurrentResults;
        }

        public int GetCurrentTime()
        {
            return _activeMatchRepository.Match.round.RoundTimeLeft;
        }
    }
}