using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Models.DTO;
using Zenject;

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