﻿
using System;
using System.Threading.Tasks;


public class CategoriesGetter : ICategoriesGetter
{
    private ICategoryService _categoryService;

    public CategoriesGetter(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<string[]> GetCategories(int amount)
    {
        if (amount <= 0)
        {
            throw new Exception("The amount is not valid");
        }

        var categories = await _categoryService.GetCategoriesNames(amount);

        return categories;
    }
}
