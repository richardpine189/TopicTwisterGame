using System.Threading.Tasks;
using Core.Match.Interface;
using Models.DTO;

public class GetRoundResultsUseCase : IGetRoundResult
{
    private readonly IGetRoundResultGateway _getRoundResults;

    GetRoundResultsUseCase(IGetRoundResultGateway getRoundResults)
    {
        _getRoundResults = getRoundResults;
    }
    public async Task<MatchResultsDTO> Execute(int matchId, int roundIndex)
    {
        return await _getRoundResults.GetRoundResults(matchId, roundIndex);
    }
}