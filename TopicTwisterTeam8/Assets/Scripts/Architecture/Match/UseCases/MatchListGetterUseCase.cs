using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Match.Domain.DTO;
using Architecture.Match.Gateway.Interfaces;
using Architecture.User.Repository;

namespace Architecture.Match.UseCases
{
    public class MatchListGetterUseCase : IGetMatchesInfoUseCase
    {
        IGetMatchesGateway _getMatchesGateway;

        ILocalPlayerDataRepository _localPlayerDataRepository;

        public MatchListGetterUseCase(IGetMatchesGateway getMatchesGateway,
            ILocalPlayerDataRepository localPlayerDataRepository)
        {
            _getMatchesGateway = getMatchesGateway;
            _localPlayerDataRepository = localPlayerDataRepository;
        }

        public async Task<List<MatchDTO>> Execute()
        {
            var playerName =_localPlayerDataRepository.GetData().name;
            return await _getMatchesGateway.GetMatchesDTOByName(playerName);
        }
    }
}