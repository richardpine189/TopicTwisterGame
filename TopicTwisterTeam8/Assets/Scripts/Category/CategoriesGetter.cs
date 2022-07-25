using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Unity.Plastic.Newtonsoft.Json;
using JsonConvert = Newtonsoft.Json.JsonConvert;

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
