using System.Threading.Tasks;
using Models.DTO;

namespace Core.Match.Interface
{
    public interface IGetRoundResultGateway
    {
        public Task<MatchResultsDTO> GetRoundResults(int matchId, int roundIndex);
    }
}