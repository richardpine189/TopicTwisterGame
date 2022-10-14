using System.Threading.Tasks;

public interface IGetCategoriesUseCase
{
    Task<string[]> Invoke(int amount);
}

