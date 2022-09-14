using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OngoingMatchView : MonoBehaviour, IOngoingMatchView
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

    [SerializeField]
    private Image _backgroundImage;

    public event Action OnStartMatch;
    public void SetRoundCount(string formatingScore)
    {
        _score.text = formatingScore;
    }

    private void Start()
    {
        //StartCoroutine(ChangeClockForButton()); ACCESS TO SKYNET
    }
    
    /* SKYNET LOGIC - REQUEST TO SOLVE
     
    IEnumerator ChangeClockForButton()
    {
        yield return new WaitForSeconds(5);
        _waitingClock.SetActive(false);
        //_presenter.BotResolveRound(matchId, new CategoriesGetter(new CategoryService())); SKYNET SOLVE
        _playButton.SetActive(true);
        SaveState();
    }

    public void SaveState()
    {
        MatchViewModel match = new MatchViewModel();
        match.idMatch = matchId;
        match.opponentName = _opponentName.text;
        match.currentRound = int.Parse(_round.text.Split(" ")[1]);
        match.isChallengerTurn = true;
        _presenter.SaveCurrentMatch(match.idMatch);
    }
    */

    public void SetOpponentName(string name)
    {
        _opponentName.text = name;
    }

    public void SetRoundNumber(int round)
    {
        _round.text = "Ronda " + round;
    }

    public void ShowWaitingClock()
    {
        _waitingClock.SetActive(true);
        _playButton.SetActive(false);
    }

    public void ShowPlayButton()
    {
        _waitingClock.SetActive(false);
        _playButton.SetActive(true);
    }

    public void LoadMatch()
    {
        OnStartMatch?.Invoke();
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void SetCardColor(System.Drawing.Color color)
    {
        _backgroundImage.color = new Color32(color.R, color.G, color.B, 255);
    }
}

