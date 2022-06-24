using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainSceneMatchListView : MonoBehaviour, IMatchListView
{
    MatchListPresenter _presenter;

    [SerializeField]
    private GameObject matchUIPrefab;

    void Start()
    {
        _presenter = new MatchListPresenter(this);
    }

    public void CreateMatchUI(MatchViewModel matchViewModel)
    {
        GameObject go = Instantiate(matchUIPrefab, new Vector2(0, 0), Quaternion.identity) as GameObject;
        go.transform.SetParent(this.transform, false);
        go.GetComponent<OngoingMatchView>().SetFields(matchViewModel);
    }


}

public class MatchListPresenter
{
    IMatchListView _view;
    public MatchListPresenter(IMatchListView view)
    {
        _view = view;
        IGetMatchesInfo action = new GetMatchesInfo();

        MatchViewModel[] matches = action.Execute();
        for (int i = 0; i < matches.Length; i++)
        {
            _view.CreateMatchUI(matches[i]);
        }
    }
}

internal class GetMatchesInfo : IGetMatchesInfo
{
    IMatchRepository _matchRepository;

    public GetMatchesInfo()
    {
        _matchRepository = ServiceLocator.Instance.GetService<IMatchRepository>();
    }

    public MatchViewModel[] Execute()
    {
        List<Match> matches = _matchRepository.GetMatches();

        if (matches != null)
        {
            return matches.Select(m => new MatchViewModel
            {
                idMatch = (int)m.id,
                opponent = m.opponent.UserName,
                currentRound = m.rounds.All(x => x == null) ? 1 : m.rounds.Where(t => t != null).Count(),
                isPlayerTurn = m.rounds.First(x => !x.roundFinished).opponentAnswers != null
            }).ToArray();
        }
        else
        {
            return new MatchViewModel[0];
        }
    }
}

public interface IMatchListView
{
    void CreateMatchUI(MatchViewModel matchViewModel);
}

