using System.Threading.Tasks;
using Architecture.Match.ActiveMatchRepository;
using Architecture.Match.Gateway.Interfaces;
using Zenject;

namespace Architecture.Match.UseCases.UpdateMatch
{
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
}
