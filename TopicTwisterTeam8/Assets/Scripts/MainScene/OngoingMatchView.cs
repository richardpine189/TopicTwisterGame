using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private GameObject _waitingClock;

    [SerializeField]
    private GameObject _playButton;
    

    private int matchId = 0;

    private OngoingMatchPresenter _presenter;


    private void Start()
    {
        _presenter = new OngoingMatchPresenter();
        StartCoroutine(ChangeClockForButton());
    }

    IEnumerator ChangeClockForButton()
    {
        yield return new WaitForSeconds(5);
        _waitingClock.SetActive(false);
        //_presenter.BotResolveRound(matchId, new CategoriesGetter(new CategoryService())); SKYNET SOLVE
        _playButton.SetActive(true);
        SaveState();
    }

    private void SaveState()
    {
        MatchViewModel match = new MatchViewModel();
        match.idMatch = matchId;
        match.opponent = _opponentName.text;
        match.currentRound = int.Parse(_round.text.Split(" ")[1]);
        match.isPlayerTurn = true;
        _presenter.SaveCurrentMatch(match.idMatch);
    }

        
    
    public void SetFields(MatchViewModel match) 
    {
        matchId = match.idMatch;
        _opponentName.text = match.opponent;
        _round.text = "Ronda " + match.currentRound;

        if(match.isPlayerTurn)
        {
            _waitingClock.SetActive(false);
            _playButton.SetActive(true);
        }
        else
        {
            _waitingClock.SetActive(true);
            _playButton.SetActive(false);
        }
    }

    public void LoadMatch()
    {
        _presenter.SaveCurrentMatch(matchId);

        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void LockButtonAndClock()
    {

    }
}

