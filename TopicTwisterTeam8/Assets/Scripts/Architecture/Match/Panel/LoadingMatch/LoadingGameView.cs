using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Architecture.Match.Panel.LoadingMatch
{
    public class LoadingGameView : MonoBehaviour, ILoadingGameView
    {
        public event Action OnReadyForPanelSelection;
        public event Action OnSendNamesInHeader;

        [SerializeField]
        private TMP_Text _playerName;

        [SerializeField]
        private TMP_Text _opponentName;
        
        [SerializeField]
        private GameObject _categoriesPanel;

        [SerializeField]
        private GameObject _endRoundPanel;

        [SerializeField]
        private ErrorPanel _panelError;
        
        [SerializeField] private GameObject _spiner;

        [SerializeField] private float waitingTimeForLoadingAnimation = 1f;
        [SerializeField] private float waitingTimeForPanelSelection = 3f;
        
        public void StartAnimation(bool isNewGame)
        {
            if (isNewGame)
                StartCoroutine(LoadingAnimation());
            else
                StartCoroutine(ShowMatchInfo());
        }

        private IEnumerator LoadingAnimation()
        {
            _spiner.gameObject.SetActive(true);
            yield return new WaitForSeconds(waitingTimeForLoadingAnimation);
            StartCoroutine(ShowMatchInfo());
        }

        public IEnumerator ShowMatchInfo()
        {
            _spiner.gameObject.SetActive(false);

            yield return new WaitForSeconds(waitingTimeForPanelSelection);

            OnReadyForPanelSelection?.Invoke();
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
            gameObject.SetActive(false);
        }

        public void ShowErrorInPanel(string errorMessage)
        {
            _panelError.gameObject.SetActive(true);
            _panelError.SetMessage(errorMessage);
        }
    }
}
