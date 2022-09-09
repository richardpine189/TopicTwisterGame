using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Serialization;

public class InMatchHeaderView : MonoBehaviour
{
    [SerializeField]
    private LetterView _letterView;

    [Header("PanelTitle")] [SerializeField]
    private TextMeshProUGUI _panelTitleText;

    [Header("Match Data")] 
    [SerializeField]
    private TextMeshProUGUI _roundNumber;

    [SerializeField]
    private GameObject _roundLetter;
    
    [SerializeField]
    private TextMeshProUGUI _challengerName;
    
    [SerializeField]
    private TextMeshProUGUI _oponentName;
    
    [SerializeField]
    private Image[] _challengerRoundResult;

    [FormerlySerializedAs("_oponentRoundResult")]
    [SerializeField]
    private Image[] _opponentRoundResult;

    [Header("Sprites References")]
    [SerializeField] private Sprite _tickSprite;
    [SerializeField] private Sprite _crossSprite;
    
    public event Action OnSetInUIPlayersName;
    public event Action OnUpdateInUIPlayersRoundsResult;
    
    // Start is called before the first frame update
    void Start()
    {
        OnSetInUIPlayersName?.Invoke();
        OnUpdateInUIPlayersRoundsResult?.Invoke();
        _letterView.UpdateLetter += SetInUIRoundLetter;
    }

    public void SetInUIPlayerName(string challenger, string oponent)
    {
        _challengerName.text = challenger;
        _oponentName.text = oponent;
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
            else if(playerRoundStatus[i] == RoundResult.Lose)
            {
                playerResult[i].sprite = _crossSprite;
            }
        }
    }

    public void SetPanelTitleText(string text)
    {
        _panelTitleText.text = text;
    }

    public void RoundNumber(string text)
    {
        _roundNumber.text = text;
    }

    private void SetInUIRoundLetter(char letter)
    {
        _roundLetter.GetComponentInChildren<TextMeshProUGUI>().text = letter.ToString();
        _roundLetter.SetActive(true);
    }
}

public enum RoundResult {Win, Lose, NotFinish}
