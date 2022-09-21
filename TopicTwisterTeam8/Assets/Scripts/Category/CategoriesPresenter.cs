using Zenject;

public class CategoriesPresenter
{
    [Inject]
    private IMatchHas _matchHas;

    private ICategoriesView _view;
    private ICategoriesGetter _categoriesGetter;
    private ISaveRoundData _saveRoundData;
    private IGetRoundData _getRoundData;

    public CategoriesPresenter(ICategoriesView view, ICategoriesGetter categoriesGetter, ISaveRoundData saveRoundData, IGetRoundData getRoundData)
    {
        _view = view;
        _categoriesGetter = categoriesGetter;
        _saveRoundData = saveRoundData;
        _getRoundData = getRoundData;
        _view.OnUpdateCategoriesField += GetCategories;
    }
    
    private async void GetCategories(int categoriesAmount)
    {
        string[] categories;

        if(!_matchHas.CurrentCategories())
        {
            categories = await _categoriesGetter.GetCategories(categoriesAmount);
            _saveRoundData.SaveCurrentCategories(categories);
        }
        else
        {
            categories = _getRoundData.GetCurrentCategories();
        }

        _view.UpdateFields(categories);
    }
}