using Core.Match.Service;
using System.Threading.Tasks;
using Core.Match.Interface;
using Zenject;

class UpdateMatchUseCase : IUpdateMatchUseCase
{
    private IUpdateMatchService _matchService;

    [Inject]
    private IActiveMatch _activeMatch;

    public UpdateMatchUseCase(IUpdateMatchService matchService)
    {
        _matchService = matchService;
    }

    public async Task<bool> Execute()
    {
        return await _matchService.UpdateMatch(_activeMatch.Match);
    }
}
