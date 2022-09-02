using System.Threading.Tasks;
using Core.Match.Interface;
using Core.Match.Service;
using Models;

namespace Core.Match
{
    public class GetCurrentMatchUseCase : IGetCurrentMatchUseCase
    {
        private IGetMatchService _matchService;

        public GetCurrentMatchUseCase(IGetMatchService service)
        {
            _matchService = service;

        }

        private const int ITS_NEW_MATCH = -1;

        public async Task<MatchDTO> Invoke(int matchId, string challenger)
        {
            MatchDTO currentMatch;
            if (matchId == ITS_NEW_MATCH)
            {
                currentMatch = await _matchService.GetNewMatch(challenger);
            }
            else
            {
                currentMatch = await _matchService.GetOnGoingMatch(matchId);
            }

            return currentMatch;
        }
    
    }
}