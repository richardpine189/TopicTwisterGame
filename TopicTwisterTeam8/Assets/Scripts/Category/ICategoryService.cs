using System.Threading.Tasks;

public interface ICategoryService
{
    Task<string[]> GetCategoriesNames(int amount);

    Task<Task<bool[]>> GetWordsCorrection(string[] roundCategories, string[] answers, char letter);
}
