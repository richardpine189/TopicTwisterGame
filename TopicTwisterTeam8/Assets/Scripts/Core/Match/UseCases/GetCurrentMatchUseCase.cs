using System.Threading.Tasks;
using Core.Match.Interface;
using Core.Match.Service;

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
            MatchDTO currentMatchDTO;
            if (matchId == ITS_NEW_MATCH)
            {
                currentMatchDTO = await _matchService.GetNewMatch(challenger);
            }
            else
            {
                currentMatchDTO = await _matchService.GetOnGoingMatch(matchId);
            }

            return currentMatchDTO;
        }
    
    }
}