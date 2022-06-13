using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

        public void SetFields(MatchViewModel match)
        {
            _opponentName.text = match.opponent;
        }
    }
}
