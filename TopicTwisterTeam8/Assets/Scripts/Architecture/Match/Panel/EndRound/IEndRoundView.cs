using System;
using Architecture.Match.Domain.DTO;

namespace Architecture.Match.Panel.EndRound
{
    public interface IEndRoundView
    {
        event Action OnSetRoundResults;

        void ShowCategories(string[] categories);

        void ShowLoggedPlayerAnswersAndResult(string[] answers, bool[] results);

        void ShowSecondPlayerAnswersAndResult(string[] answers, bool[] results);

        void ShowEndGamePanel(WinnerStatus winner);
    }
}

