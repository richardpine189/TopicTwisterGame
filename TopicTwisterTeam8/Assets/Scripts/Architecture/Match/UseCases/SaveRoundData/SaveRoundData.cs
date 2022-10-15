using Architecture.Match.ActiveMatchRepository;

namespace Architecture.Match.UseCases.SaveRoundData
{
    class SaveRoundData : ISaveRoundDataUseCase
    {
        IActiveMatchRepository _matchRepositoryUseCase;

        public SaveRoundData(IActiveMatchRepository matchRepositoryUseCase)
        {
            _matchRepositoryUseCase = matchRepositoryUseCase;
        }

        public void SaveLetter(char letter)
        {
            _matchRepositoryUseCase.Match.round.CurrentLetter = letter;
        }

        public void SaveCurrentCategories(string[] categories)
        {
            _matchRepositoryUseCase.Match.round.CurrentCategories = categories;
        }

        public void SaveCurrentAnswers(string[] answers)
        {
            _matchRepositoryUseCase.Match.round.CurrentAnswers = answers;
        }

        public void SaveCurrentResults(bool[] results)
        {
            _matchRepositoryUseCase.Match.round.CurrentResults = results;
        }

        public void SaveCurrentTime(int time)
        {
            _matchRepositoryUseCase.Match.round.RoundTimeLeft = time;
        }
    }
}






