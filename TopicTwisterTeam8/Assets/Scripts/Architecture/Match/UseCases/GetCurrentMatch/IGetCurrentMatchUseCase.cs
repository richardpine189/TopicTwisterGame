using System.Threading.Tasks;
using Architecture.Match.Domain.DTO;

namespace Architecture.Match.UseCases.GetCurrentMatch
{
    public interface IGetCurrentMatchUseCase
    {
        Task<MatchDTO> Invoke(string challenger);

        Task<ActiveMatchDTO> Invoke(int matchId);
    }
}