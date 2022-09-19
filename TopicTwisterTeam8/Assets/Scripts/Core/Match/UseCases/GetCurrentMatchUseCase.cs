using System.Threading.Tasks;
using Core.Match.Interface;
using Core.Match.Service;
using Models;
using Models.DTO;

namespace Core.Match
{
    public class GetCurrentMatchUseCase : IGetCurrentMatchUseCase
    {
        private IGetMatchGateway _matchGateway;

        public GetCurrentMatchUseCase(IGetMatchGateway gateway)
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