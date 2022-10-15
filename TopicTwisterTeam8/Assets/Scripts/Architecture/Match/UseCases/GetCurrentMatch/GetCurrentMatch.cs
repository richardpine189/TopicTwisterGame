using System.Threading.Tasks;
using Architecture.Match.Domain.DTO;
using Architecture.Match.Gateway.Interfaces;

namespace Architecture.Match.UseCases.GetCurrentMatch
{
    public class GetCurrentMatch : IGetCurrentMatchUseCase
    {
        private IGetMatchGateway _matchGateway;

        public GetCurrentMatch(IGetMatchGateway gateway)
        {
            _matchGateway = gateway;
        }

        public async Task<ActiveMatchDTO> Invoke(int matchId)
        {
            return await _matchGateway.GetActiveMatch(matchId);
        }

        public async Task<MatchDTO> Invoke(string challenger)
        {
           return await _matchGateway.GetNewMatch(challenger);

        }
    
    }
}