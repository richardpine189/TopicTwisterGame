using System.Threading.Tasks;

namespace Architecture.Category.UseCases.GetCorrection
{
    public class CorrectionGetter : IGetCorrections
    {
        private Gateway.ICategoryService _service;

        public CorrectionGetter(Gateway.ICategoryService service)
        {
            _service = service;
        }

        public async Task<bool[]> GetCorrections(string[] roundCategories, string[] answers, char letter)
        {
            return await _service.GetWordsCorrection(roundCategories, answers, letter);
        }
    }
}