using UnityEngine;
using Zenject;

class GetDataMatchInMemory : IGetMatchCategoriesUseCase, IGetMatchLetterUseCase, IGetMatchAnswersUseCase, IGetMatchResultsUseCase, IGetMatchOpponentUseCase, IGetMatchChallengerUseCase, IGetMatchRoundNumber
{
    [Inject]
    private IActiveMatch _activeMatch;

    string[] IGetMatchCategoriesUseCase.Execute()
    {
        return _activeMatch.Match.currentCategories;
    }

    char? IGetMatchLetterUseCase.Execute()
    {
        return _activeMatch.Match.currentLetter;
    }

    string[] IGetMatchAnswersUseCase.Execute()
    {
        return _activeMatch.Match.currentAnswers;
    }

    bool[] IGetMatchResultsUseCase.Execute()
    {
        return _activeMatch.Match.currentResults;
    }

    string IGetMatchOpponentUseCase.Execute()
    {
        return _activeMatch.Match.opponentName;
    }

    string IGetMatchChallengerUseCase.Execute()
    {
        return _activeMatch.Match.challengerName;
    }

    int IGetMatchRoundNumber.Execute()
    {
        return _activeMatch.Match.currentRound;
    }
}