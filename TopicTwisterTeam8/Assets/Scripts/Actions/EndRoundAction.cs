
    public class EndRoundAction : IEndRoundAction
    {
        private Match _currentMatch; 

        public EndRoundAction()
        {
            _currentMatch = CurrentMatchSingleton.Get();
        }

        public string[] GetCategories()
        {
            return _currentMatch.rounds[0].assignedCategoryNames;
        }

        public string[] GetChallengerAnswers()
        {
            return _currentMatch.rounds[0].challengerAnswers;
        }

        public bool[] GetChallengerResults()
        {
            return _currentMatch.rounds[0].challengerResult;
        }

        public string[] GetOponentAnswers()
        {
            return _currentMatch.rounds[0].opponentAnswers;
        }

        public bool[] GetOponentResults()
        {
            return _currentMatch.rounds[0].oponentResult;
        }
    }
