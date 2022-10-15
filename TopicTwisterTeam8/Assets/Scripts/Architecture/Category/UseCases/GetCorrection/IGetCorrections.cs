using System.Threading.Tasks;

namespace Architecture.Category.UseCases.GetCorrection
{
    public interface IGetCorrections
    {
        Task<bool[]> GetCorrections(string[] roundCategories, string[] answers, char letter);
    }
}