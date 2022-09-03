using System.Threading.Tasks;

public interface ICategoriesGetter
{
    Task<string[]> GetCategories(int amount);
}

