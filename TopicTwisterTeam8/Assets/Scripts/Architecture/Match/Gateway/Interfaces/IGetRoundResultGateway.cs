using System.Threading.Tasks;
using Architecture.Match.Domain.DTO;

namespace Architecture.Match.Gateway.Interfaces
{
    public interface IGetRoundResultGateway
    {
        public Task<RoundResultsDTO> GetRoundResults(int matchId);
    }
}