using Core.Match.Service;
using System.Threading.Tasks;
using Zenject;

class UpdateMatchUseCase : IUpdateMatchUseCase
{
    private MatchService _matchService;

    [Inject]
    private IActiveMatch _activeMatch;

    public UpdateMatchUseCase(MatchService matchService)
    {
        _matchService = matchService;
    }

    public async Task<bool> Execute()
    {
        return await _matchService.UpdateMatch(_activeMatch.Match);
    }
}
