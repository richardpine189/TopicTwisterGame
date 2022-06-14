using Assets.Scripts.Repositories;
using TopicTwister.Assets.Scripts.Models;

namespace Team8.TopicTwister
{
    public class EndRoundAction : IEndRoundAction
    {
        private Match _currentMatch; 
        public EndRoundAction()
        {
            _currentMatch = CurrentMatchSingleton.Get();
        }
        public string[] GetCategories()
        {
            throw new System.NotImplementedException();
        }

        public string[] GetChallengerAnswers()
        {
            throw new System.NotImplementedException();
        }

        public bool[] GetChallengerResults()
        {
            throw new System.NotImplementedException();
        }

        public string[] GetOponentAnswers()
        {
            throw new System.NotImplementedException();
        }

        public bool[] GetOponentResults()
        {
            throw new System.NotImplementedException();
        }
    }
}
