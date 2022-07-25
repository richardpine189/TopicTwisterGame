
    public interface IEndRoundView
    {
        void ShowCategories(string[] categories);

        void ShowChallengerAnswersAndResult(string[] answers, CorrectionStatus[] results);

        void ShowOponentAnswersAndResult(string[] answers, CorrectionStatus[] results);
    void ShowEndGamePanel(bool v);
}

