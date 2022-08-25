using System.Threading.Tasks;

namespace Core.Match.Interface
{
    public interface IGetMatchService
    {
        Task<MatchDTO> GetNewMatch(string challenger);
        Task<MatchDTO> GetOnGoingMatch(int matchId);
    }
}