using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Architecture.OnGoingMatch.Card
{
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

        private TransitionLoadingView _transitionLoading;

        private void Start()
        {
            _transitionLoading = GameObject.Find("Transition").GetComponent<TransitionLoadingView>();
        }

        public event Action OnStartMatch;
        public void SetRoundCount(string formatingScore)
        {
            _score.text = formatingScore;
        }

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
            _turn.text = "Esperando al oponente";
        }

        public void ShowPlayButton()
        {
            _waitingClock.SetActive(false);
            _playButton.SetActive(true);
            _turn.text = "Es su turno";
        }

        public void ShowFinishedMatchText()
        {
            _waitingClock.SetActive(false);
            _playButton.SetActive(false);
            _turn.text = "Partida Terminada";
        }

        public void LoadMatch()
        {
            OnStartMatch?.Invoke();
            
            _transitionLoading.SlideUp();
            StartCoroutine(WaitingForEndTransitionAnimation());
            
        }
        IEnumerator WaitingForEndTransitionAnimation()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }

        public void SetCardColor(System.Drawing.Color color)
        {
            _backgroundImage.color = new Color32(color.R, color.G, color.B, 255);
        }
    }
}

