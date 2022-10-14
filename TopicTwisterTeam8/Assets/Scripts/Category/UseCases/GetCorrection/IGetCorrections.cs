using System.Threading.Tasks;

public interface IGetCorrections
{
    Task<bool[]> GetCorrections(string[] roundCategories, string[] answers, char letter);
}