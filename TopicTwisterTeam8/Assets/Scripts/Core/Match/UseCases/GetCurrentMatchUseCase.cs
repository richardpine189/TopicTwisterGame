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

        public async Task<ActiveMatchDTO> Invoke(int matchId)
        {
            return await _matchService.GetActiveMatch(matchId);
        }

        public async Task<MatchDTO> Invoke(string challenger)
        {
           return await _matchService.GetNewMatch(challenger);

        }
    
    }
}