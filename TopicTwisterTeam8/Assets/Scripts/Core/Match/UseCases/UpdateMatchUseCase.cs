using Core.Match.Service;
using System.Threading.Tasks;
using Core.Match.Interface;
using Zenject;

class UpdateMatchUseCase : IUpdateMatchUseCase
{
    private IUpdateMatchGateway _matchGateway;

    [Inject]
    private IActiveMatch _activeMatch;

    public UpdateMatchUseCase(IUpdateMatchGateway matchGateway)
    {
        _matchGateway = matchGateway;
    }

    public async Task<bool> Execute()
    {
        return await _matchGateway.UpdateMatch(_activeMatch.Match);
    }
}
