using Zenject;

class GetDataMatchInMemory : IGetMatchCategoriesUseCase, IGetMatchLetterUseCase, IGetMatchAnswersUseCase, IGetMatchResultsUseCase
{
    [Inject]
    private IActiveMatch _activeMatch;

    string[] IGetMatchCategoriesUseCase.Execute()
    {
        return _activeMatch.Match.currentCategories;
    }

    char IGetMatchLetterUseCase.Execute()
    {
        return (char)_activeMatch.Match.currentLetter;
    }

    string[] IGetMatchAnswersUseCase.Execute()
    {
        return _activeMatch.Match.currentAnswers;
    }

    bool[] IGetMatchResultsUseCase.Execute()
    {
        return _activeMatch.Match.currentResults;
    }
}
