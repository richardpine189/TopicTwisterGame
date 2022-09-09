using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Zenject;

public class MatchListGetterUseCase : IGetMatchesInfoUseCase
{
    IGetMatchesService _getMatchesService;

    ILocalPlayerDataRepository _localPlayerDataRepository;

    public MatchListGetterUseCase(IGetMatchesService getMatchesService,
        ILocalPlayerDataRepository localPlayerDataRepository)
    {
        _getMatchesService = getMatchesService;
        _localPlayerDataRepository = localPlayerDataRepository;
    }
    public async Task<List<MatchDTO>> Execute()
    {
        var playerName =_localPlayerDataRepository.GetData().name;
        return await _getMatchesService.GetMatchesDTOByName(playerName);
    }
}