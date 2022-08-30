using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zenject;

public class MatchListGetter : IGetMatchesInfo
{
    IGetMatches _getMatchesAction;

    ILocalPlayerDataRepository _localPlayerDataRepository;

    public MatchListGetter(IGetMatches getMatchesAction, ILocalPlayerDataRepository localPlayerDataRepository)
    {
        _getMatchesAction = getMatchesAction;
        _localPlayerDataRepository = localPlayerDataRepository;
    }
    
    public async Task<List<MatchDTO>> Execute()
    {
        return await _getMatchesAction.GetMatchesDTOByName(_localPlayerDataRepository.GetData().name);
    }
}