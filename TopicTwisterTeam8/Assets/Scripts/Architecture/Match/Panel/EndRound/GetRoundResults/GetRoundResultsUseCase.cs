using System.Threading.Tasks;
using Architecture.Match.Domain.DTO;
using Architecture.Match.Gateway.Interfaces;

namespace Architecture.Match.Panel.EndRound.GetRoundResults
{
    public class GetRoundResultsUseCase : IGetRoundResult
    {
        private readonly IGetRoundResultGateway _getRoundResults;

        GetRoundResultsUseCase(IGetRoundResultGateway getRoundResults)
        {
            _getRoundResults = getRoundResults;
        }
        public async Task<RoundResultsDTO> Execute(int matchId)
        {
            return await _getRoundResults.GetRoundResults(matchId);
        }
    }
}