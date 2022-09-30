using System.Threading.Tasks;
using Models.DTO;

public interface IGetRoundResult
{
    Task<MatchResultsDTO> Execute(int matchId);
}