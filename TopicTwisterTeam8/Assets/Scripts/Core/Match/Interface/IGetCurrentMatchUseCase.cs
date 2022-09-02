using System.Threading.Tasks;
using Models;

namespace Core.Match.Interface
{
    public interface IGetCurrentMatchUseCase
    {
        Task<MatchDTO> Invoke(int matchId, string challenger);
    }
}