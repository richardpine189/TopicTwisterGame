using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Zenject;

public class MatchListGetterUseCase : IGetMatchesInfoUseCase
{
    [Inject] IGetMatchesService _getMatchesServiceService;

    [Inject] ILocalPlayerDataRepository _localPlayerDataRepository;

    public MatchListGetterUseCase() { }

    /*public MatchListGetterUseCase(IGetMatchesService getMatchesServiceService, ILocalPlayerDataRepository localPlayerDataRepository)
    {
        _getMatchesServiceService = getMatchesServiceService;
        _localPlayerDataRepository = localPlayerDataRepository;
    }
    */
    public async Task<List<MatchDTO>> Execute()
    {
        
        return await _getMatchesServiceService.GetMatchesDTOByName(_localPlayerDataRepository.GetData().name);
    }
}