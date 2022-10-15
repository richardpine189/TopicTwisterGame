using System.Threading.Tasks;

namespace Architecture.Category.Gateway
{
    public interface ICategoryService
    {
        Task<string[]> GetCategoriesNames(int amount);

        Task<bool[]> GetWordsCorrection(string[] roundCategories, string[] answers, char letter);
    }
}
