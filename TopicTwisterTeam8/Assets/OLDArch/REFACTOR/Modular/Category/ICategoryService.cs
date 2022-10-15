using System.Threading.Tasks;

public interface ICategoryService
{
    Task<string[]> GetCategoriesNames(int amount);
    Task<bool[]> GetWordCorrection();
}
