
    public interface IEndRoundView
    {
        void ShowCategories(string[] categories);

        void ShowChallengerAnswersAndResult(string[] answers, bool[] results);

        void ShowOponentAnswersAndResult(string[] answers, bool[] results);
    }

