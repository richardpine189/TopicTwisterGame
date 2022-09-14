
    using System;

    public interface IEndRoundView
    {
        event Action OnSetRoundResults;
        void ShowCategories(string[] categories);

        void ShowChallengerAnswersAndResult(string[] answers, bool[] results);

        void ShowOponentAnswersAndResult(string[] answers, bool[] results);
        void ShowEndGamePanel(bool v);
}

