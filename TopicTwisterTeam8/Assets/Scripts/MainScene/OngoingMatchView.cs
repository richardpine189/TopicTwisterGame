using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Team8.TopicTwister
{
    public class OngoingMatchView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _opponentName;

        [SerializeField]
        private TMP_Text _score;

        [SerializeField]
        private TMP_Text _round;

        [SerializeField]
        private TMP_Text _turn;

        private int matchId;

        private OngoingMatchPresenter _presenter;

        private void Start()
        {
            _presenter = new OngoingMatchPresenter();
        }

        public void SetFields(MatchViewModel match)
        {
            matchId = match.idMatch;
            _opponentName.text = match.opponent;
        }

        public void LoadMatch()
        {
            _presenter.SaveCurrentMatch(matchId);

            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
}
