using System.Threading.Tasks;
using Models;
using Models.DTO;

namespace Core.Match.Interface
{
    public interface IGetCurrentMatchUseCase
    {
        Task<MatchDTO> Invoke(string challenger);

        Task<ActiveMatchDTO> Invoke(int matchId);
    }
}