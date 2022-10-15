using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Match.Domain.DTO;

namespace Architecture.Match.UseCases
{
    public interface IGetMatchesInfoUseCase
    {
        Task<List<MatchDTO>> Execute();
    }
}

