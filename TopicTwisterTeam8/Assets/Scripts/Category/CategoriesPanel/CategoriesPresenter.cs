using Zenject;

public class CategoriesPresenter
{
    [Inject]
    private IMatchHasUseCase _matchHasUseCase;

    private ICategoriesView _view;
    private IGetCategoriesUseCase _getCategoriesUseCase;
    private ISaveRoundDataUseCase _saveRoundDataUseCase;
    private IGetRoundDataUseCase _getRoundDataUseCase;

    public CategoriesPresenter(ICategoriesView view, IGetCategoriesUseCase getCategoriesUseCase, ISaveRoundDataUseCase saveRoundDataUseCase, IGetRoundDataUseCase getRoundDataUseCase)
    {
        _view = view;
        _getCategoriesUseCase = getCategoriesUseCase;
        _saveRoundDataUseCase = saveRoundDataUseCase;
        _getRoundDataUseCase = getRoundDataUseCase;
        _view.OnUpdateCategoriesField += GetCategories;
    }
    
    private async void GetCategories(int categoriesAmount)
    {
        string[] categories;

        if(!_matchHasUseCase.CurrentCategories())
        {
            categories = await _getCategoriesUseCase.Invoke(categoriesAmount);
            _saveRoundDataUseCase.SaveCurrentCategories(categories);
        }
        else
        {
            categories = _getRoundDataUseCase.GetCurrentCategories();
        }

        _view.UpdateFields(categories);
    }
}