using System.Threading.Tasks;
using Core.Match.Interface;
using Models.DTO;

public class GetRoundResultsUseCase : IGetRoundResult
{
    private readonly IGetRoundResultService _getRoundResults;

    GetRoundResultsUseCase(IGetRoundResultService getRoundResults)
    {
        _getRoundResults = getRoundResults;
    }
    public async Task<MatchResultsDTO> Execute(int matchId)
    {
        return await _getRoundResults.GetRoundResults(matchId);
    }
}