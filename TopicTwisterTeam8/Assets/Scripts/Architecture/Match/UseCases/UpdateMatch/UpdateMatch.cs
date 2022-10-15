using Core.Match.Service;
using System.Threading.Tasks;
using Core.Match.Interface;
using Zenject;

class UpdateMatch : IUpdateMatchUseCase
{
    private IUpdateMatchGateway _matchGateway;

    [Inject]
    private IActiveMatchRepository _activeMatchRepository;

    public UpdateMatch(IUpdateMatchGateway matchGateway)
    {
        _matchGateway = matchGateway;
    }

    public async Task<bool> Invoke()
    {
        return await _matchGateway.UpdateMatch(_activeMatchRepository.Match);
    }
}
