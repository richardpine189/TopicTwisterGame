using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InMatchHeaderView : MonoBehaviour
{
    [Header("Match Data")]
    
    [SerializeField] private TextMeshProUGUI _challengerName;
    [SerializeField] private TextMeshProUGUI _oponentName;
    [SerializeField] private Image[] _challengerRoundResult;
    [SerializeField] private Image[] _oponentRoundResult;

    [Header("Sprites References")]
    
    [SerializeField] private Sprite _tickSprite;
    [SerializeField] private Sprite _crossSprite;
    
    public event Action OnSetInUIPlayersName;
    public event Action OnUpdateInUIPlayersRoundsResult;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        OnSetInUIPlayersName?.Invoke();
        OnUpdateInUIPlayersRoundsResult();
    }

    void SetInUIPlayerName(string challenger, string oponent)
    {
        _challengerName.text = challenger;
        _oponentName.text = oponent;
    }

    void SetInUIPlayerRoundResult(RoundResult[] challengerRoundStatus, RoundResult[] oponentRoundStatus)
    {
        for (int i = 0; i < challengerRoundStatus.Length; i++)
        {
            if (challengerRoundStatus[i] == RoundResult.Win)
            {
                _challengerRoundResult[i].sprite = _tickSprite;
            }
            else if(challengerRoundStatus[i] == RoundResult.Lose)
            {
                _challengerRoundResult[i].sprite = _crossSprite;
            }
        }
        
        //NO ME GUSTA LA REPETICION DE CODIGO, HABRIA QUE MANDAR EL USER A CAMBIAR.
        
        for (int i = 0; i < oponentRoundStatus.Length; i++)
        {
            if (oponentRoundStatus[i] == RoundResult.Win)
            {
                _oponentRoundResult[i].sprite = _tickSprite;
            }
            else if(oponentRoundStatus[i] == RoundResult.Lose)
            {
                _oponentRoundResult[i].sprite = _crossSprite;
            }
        }
    }
}

public enum RoundResult {Win, Lose, NotFinish}
