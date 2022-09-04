class SaveDataMatchInMemory : ISaveLetterUseCase, IAssignCategoriesUseCase, IAssignAnswersUseCase, IAssignResultsUseCase
{
    IActiveMatch _matchUseCase;

    public SaveDataMatchInMemory(IActiveMatch matchUseCase)
    {
        _matchUseCase = matchUseCase;
    }

    public void Execute(char letter)
    {
        _matchUseCase.Match.currentLetter = letter;
    }

    void IAssignCategoriesUseCase.Execute(string[] categories)
    {
        _matchUseCase.Match.currentCategories = categories;
    }

    void IAssignAnswersUseCase.Execute(string[] answers)
    {
        _matchUseCase.Match.currentAnswers = answers;
    }

    void IAssignResultsUseCase.Execute(bool[] results)
    {
        _matchUseCase.Match.currentResults = results;
    }
}
