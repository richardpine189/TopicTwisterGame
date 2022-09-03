﻿using System;
using Zenject;

public class CategoriesPresenter : IInitializable, IDisposable
{
    [Inject]
    private IMatchHas _matchHas;

    private ICategoriesView _view;
    private ICategoriesGetter _categoriesGetter;
    private IAssignCategoriesUseCase _assignCategories;
    private IGetMatchCategories _getMatchCategories;

    public CategoriesPresenter(ICategoriesView view, ICategoriesGetter categoriesGetter, IAssignCategoriesUseCase assignCategories, IGetMatchCategories getMatchCategories)
    {
        _view = view;
        _categoriesGetter = categoriesGetter;
        _assignCategories = assignCategories;
        _getMatchCategories = getMatchCategories;
        _view.OnUpdateCategoriesField += GetCategories;
    }

    public void Dispose()
    {
    }

    public void Initialize()
    {
    }

    private async void GetCategories(int categoriesAmount)
    {
        string[] categories;

        if(!_matchHas.CurrentCategories())
        {
            categories = await _categoriesGetter.GetCategories(categoriesAmount);
            _assignCategories.Execute(categories);
        }
        else
        {
            categories = _getMatchCategories.Execute();
        }

        _view.UpdateFields(categories);
    }
}