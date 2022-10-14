using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Serialization;

namespace Core.Match
{
    public class MatchHeaderView : MonoBehaviour, IMatchHeaderView
    {
        
        [Header("Match Data")] [SerializeField]
        private TextMeshProUGUI _roundNumber;

        [SerializeField]
        private Image[] _challengerRoundResult;

        [SerializeField]
        private Image[] _opponentRoundResult;

        [Header("Sprites References")] 
        
        [SerializeField]
        private Sprite _tickSprite;

        [SerializeField] 
        private Sprite _crossSprite;
     
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
                if (playerRoundStatus[i] != RoundResult.NotFinish)
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
            _roundNumber.text = "Round " + roundNumber;
        }
    }
}

public enum RoundResult {Win, Lose, NotFinish}
