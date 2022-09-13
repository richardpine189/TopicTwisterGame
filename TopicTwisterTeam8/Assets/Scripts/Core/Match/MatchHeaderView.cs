using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Serialization;

namespace Core.Match
{
    public class MatchHeaderView : MonoBehaviour, IMatchHeaderView
    {
        [SerializeField] private LetterView _letterView;
        [SerializeField] private GameObject _roundLetter;
        [Header("PanelTitle")] [SerializeField]
        private TextMeshProUGUI _panelTitleText;

        [Header("Match Data")] [SerializeField]
        private TextMeshProUGUI _roundNumber;

        [SerializeField] private TextMeshProUGUI _challengerName;

        [SerializeField] private TextMeshProUGUI _oponentName;

        [SerializeField] private Image[] _challengerRoundResult;

        [SerializeField]
        private Image[] _opponentRoundResult;

        [Header("Sprites References")] 
        
        [SerializeField]
        private Sprite _tickSprite;

        [SerializeField] 
        private Sprite _crossSprite;

        
        public void SetPanelTitleText(string text)
        {
            _panelTitleText.text = text;
        }

        public void SetInUIPlayerName(string challenger, string opponent)
        {
            _challengerName.text = challenger;
            _oponentName.text = opponent;
        }

        public void SetInUIPlayerRoundResult(bool isChallenger, RoundResult[] playerRoundStatus)
        {
            Image[] playerResult;
            if (isChallenger)
            {
                playerResult = _challengerRoundResult;
            }
            else
            {
                playerResult = _opponentRoundResult;
            }

            for (int i = 0; i < playerRoundStatus.Length; i++)
            {
                if (playerRoundStatus[i] == RoundResult.NotFinish)
                {
                    playerResult[i].gameObject.SetActive(true);
                }

                if (playerRoundStatus[i] == RoundResult.Win)
                {
                    playerResult[i].sprite = _tickSprite;
                }
                else if (playerRoundStatus[i] == RoundResult.Lose)
                {
                    playerResult[i].sprite = _crossSprite;
                }
            }
        }

        

        public void SetInUIRoundNumber(string roundNumber)
        {
            _roundNumber.text = "Round" + roundNumber;
        }

        public void SetRoundLetter(string letter)
        {
            _roundLetter.GetComponentInChildren<TextMeshProUGUI>().text = letter;
            _roundLetter.SetActive(true);
        }
    }
}

public enum RoundResult {Win, Lose, NotFinish}
