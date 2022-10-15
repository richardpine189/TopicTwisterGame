using System.Threading.Tasks;

namespace Architecture.Category.UseCases.GetCategories
{
    public interface IGetCategoriesUseCase
    {
        Task<string[]> Invoke(int amount);
    }
}

