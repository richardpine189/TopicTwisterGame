using Assets.Scripts.Presenters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Team8.TopicTwister
{
    
    public class LoadingGameView : MonoBehaviour, ILoadingGameView
    {
        public event Action OnReadyForNext;

        [SerializeField]
        private TMP_Text _playerName;

        [SerializeField]
        private TMP_Text _opponentName;

        [SerializeField]
        private TMP_Text _loadingText;

        [SerializeField]
        private GameObject _versusImage;

        [SerializeField]
        private GameObject _categoriesPanel;

        [SerializeField]
        private GameObject _endRoundPanel;

        private LoadingGamePresenter _presenter;

        [SerializeField] private GameObject _spiner;
        

        bool _isNewGame;

        private void Start()
        {
            _presenter = new LoadingGamePresenter(this);
        }

        public void StartAnimation()
        {
            if (_isNewGame)
                // Simulated loading, change name, refactor
                StartCoroutine(LoadingAnimation());
            else
                StartCoroutine(SecondWaiting());

        }

        private IEnumerator LoadingAnimation()
        {
            _spiner.gameObject.SetActive(true);
            _versusImage.SetActive(false);
            yield return new WaitForSeconds(1f);
            StartCoroutine(SecondWaiting());
        }

        public IEnumerator SecondWaiting()
        {
            _spiner.gameObject.SetActive(false);
            _versusImage.SetActive(true);

            yield return new WaitForSeconds(3.0f);

            OnReadyForNext?.Invoke();
        }

        public void ShowPlayersInfo(string playerName, string opponentName)
        {
            _playerName.text = playerName;
            _opponentName.text = opponentName;
        }
        
        public void ShowCategoriesSection()
        {
            _categoriesPanel.SetActive(true);
            DeactivateLoading();
        }

        public void ShowEndRoundSection()
        {
            _endRoundPanel.SetActive(true);
            DeactivateLoading();
        }

        private void DeactivateLoading()
        {
            this.gameObject.SetActive(false);
        }
        public void SetNewGameState(bool gameState)
        {
            _isNewGame = gameState;
        }
    }
}
