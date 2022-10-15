using System.Threading.Tasks;
using Architecture.Match.Domain.DTO;

namespace Architecture.Match.Panel.EndRound.GetRoundResults
{
    public interface IGetRoundResult
    {
        Task<RoundResultsDTO> Execute(int matchId);
    }
}