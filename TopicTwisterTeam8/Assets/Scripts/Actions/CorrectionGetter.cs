using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CorrectionGetter : IGetCorrections
{
    private ICategoryService _service;

    public CorrectionGetter(ICategoryService service)
    {
        _service = service;
    }

    public async Task<bool[]> GetCorrections(string[] roundCategories, string[] answers, char letter)
    {
        return await _service.GetWordsCorrection(roundCategories, answers, letter);
    }
}