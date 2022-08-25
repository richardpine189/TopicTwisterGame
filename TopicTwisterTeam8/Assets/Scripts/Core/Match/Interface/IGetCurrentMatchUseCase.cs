using System.Threading.Tasks;

namespace Core.Match.Interface
{
    public interface IGetCurrentMatchUseCase
    {
        Task<MatchDTO> Invoke(int matchId, string challenger);
    }
}