using System.Threading.Tasks;
using Models.DTO;

namespace Core.Match.Interface
{
    public interface IGetRoundResultGateway
    {
        public Task<RoundResultsDTO> GetRoundResults(int matchId);
    }
}