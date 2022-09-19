using System.Threading.Tasks;
using Models;
using Models.DTO;

namespace Core.Match.Interface
{
    public interface IGetMatchGateway
    {
        Task<MatchDTO> GetNewMatch(string challenger);

        Task<ActiveMatchDTO> GetActiveMatch(int matchId);
    }
}