class SaveDataMatchInMemory : ISaveLetterUseCase, IAssignCategoriesUseCase
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

    public void Execute(string[] categories)
    {
        _matchUseCase.Match.currentCategories = categories;
    }
}
