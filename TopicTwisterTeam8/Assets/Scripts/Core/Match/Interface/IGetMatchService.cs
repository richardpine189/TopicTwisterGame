using System.Threading.Tasks;
using Models;

namespace Core.Match.Interface
{
    public interface IGetMatchService
    {
        Task<MatchDTO> GetNewMatch(string challenger);
        Task<ActiveMatchDTO> GetActiveMatch(int matchId);
    }
}