using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TopicTwister.Assets.Scripts.Models;
using UnityEngine;

namespace Team8.TopicTwister
{
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
            IMatchInfoGetter action = new MatchGetter();

            foreach(var match in action.GetMatchesInfo())
            {
                _view.CreateMatchUI(match);
            }
        }
    }

    internal class MatchGetter : IMatchInfoGetter
    {
        IMatchRepository _matchRepository;

        public MatchGetter()
        {
            _matchRepository = ServiceLocator.Instance.GetService<IMatchRepository>();
        }

        public MatchViewModel[] GetMatchesInfo()
        {
            List<Match> matches = _matchRepository.GetMatches();

            if (matches != null)
            {
                return matches.Select(m => new MatchViewModel
                {
                    idMatch = (int)m.id,
                    opponent = m.opponent.UserName,
                    currentRound = m.rounds.TakeWhile(t => t == null).Count(),
                    isPlayerTurn = false
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
}
