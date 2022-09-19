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
        public event Action OnSendNamesInHeader;

        [SerializeField]
        private TMP_Text _playerName;

        [SerializeField]
        private TMP_Text _opponentName;

        [SerializeField]
        private GameObject _versusImage;

        [SerializeField]
        private GameObject _categoriesPanel;

        [SerializeField]
        private GameObject _endRoundPanel;

        [SerializeField] private GameObject _spiner;
        private const int ITS_NEW_MATCH = -1;

        public void StartAnimation(bool isNewGame)
        {
            if (isNewGame)
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
            OnSendNamesInHeader?.Invoke();
        }

        public void SetChallenger(string challengerName)
        {
            _playerName.text = challengerName;

        }
        public void SetOpponent(string opponentName)
        {

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

    }
}
