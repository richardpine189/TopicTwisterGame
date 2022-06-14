namespace Team8.TopicTwister
{
    public interface IEndRoundAction
    {
        public string[] GetCategories();
        public string[] GetChallengerAnswers();
        public string[] GetOponentAnswers();
        public bool[] GetChallengerResults();
        public bool[] GetOponentResults();
    }
}
