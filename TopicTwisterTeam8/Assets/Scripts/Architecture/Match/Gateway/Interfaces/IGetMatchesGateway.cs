using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Match.Domain.DTO;

namespace Architecture.Match.Gateway.Interfaces
{
    public interface IGetMatchesGateway
    {
        Task<List<MatchDTO>> GetMatchesDTOByName(string userName);
    }
}
