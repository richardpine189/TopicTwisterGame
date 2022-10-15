using System;
using System.Threading.Tasks;

namespace Architecture.Category.UseCases.GetCategories
{
    public class GetCategories : IGetCategoriesUseCase
    {
        private Gateway.ICategoryService _categoryService;

        public GetCategories(Gateway.ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<string[]> Invoke(int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("The amount is not valid");
            }

            var categories = await _categoryService.GetCategoriesNames(amount);

            return categories;
        }
    }
}
