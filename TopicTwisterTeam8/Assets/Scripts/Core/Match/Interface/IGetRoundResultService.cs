using System.Threading.Tasks;
using Models.DTO;

namespace Core.Match.Interface
{
    public interface IGetRoundResultService
    {
        public Task<MatchResultsDTO> GetRoundResults(int matchId, int roundIndex);
    }
}