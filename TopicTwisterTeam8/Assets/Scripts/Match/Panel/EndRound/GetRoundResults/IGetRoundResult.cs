using System.Threading.Tasks;
using Models.DTO;

public interface IGetRoundResult
{
    Task<RoundResultsDTO> Execute(int matchId);
}