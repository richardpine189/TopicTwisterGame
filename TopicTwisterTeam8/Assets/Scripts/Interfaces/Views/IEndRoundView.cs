namespace Team8.TopicTwister
{
    public interface IEndRoundView
    {
        public void ShowCategories(string[] categories);
        public void ShowChallengerAnswersAndResult(string[] categories, bool[] results);
        public void ShowOponentAnswersAndResult(string[] categories, bool[] results);
    }
}
