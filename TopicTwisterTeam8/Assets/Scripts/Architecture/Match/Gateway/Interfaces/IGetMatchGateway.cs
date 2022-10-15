using System.Threading.Tasks;
using Architecture.Match.Domain.DTO;

namespace Architecture.Match.Gateway.Interfaces
{
    public interface IGetMatchGateway
    {
        Task<MatchDTO> GetNewMatch(string challenger);

        Task<ActiveMatchDTO> GetActiveMatch(int matchId);
    }
}