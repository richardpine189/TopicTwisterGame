using System;
using System.Collections;
using Architecture.Match.MatchHeader.TitleHeaderView;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Architecture.Category.CorrectionPanel
{
    public class CorrectionView : MonoBehaviour, ICorrectionView
    {
        public event Action OnEndTurn;

        public event Action OnGetCorrections;
    
        private const string PANEL_NAME = "CORRECCION";

        [SerializeField]
        private TMP_Text[] _answersUI;

        [SerializeField]
        private Image[] _resultsUI;
    
        [SerializeField]
        private GameObject[] _recommendButton;

        [SerializeField]
        private Sprite _tickSprite;

        [SerializeField]
        private Sprite _crossSprite;

        [SerializeField]
        private GameObject _endRoundPanel;

        [SerializeField]
        private ErrorPanel _errorPanel;

        [SerializeField]
        private GameObject _spiner;

        [SerializeField]
        private TransitionLoadingView _transitionLoading;

        private void OnEnable()
        {
            OnGetCorrections?.Invoke();
            TitleSetName.SendPanelName(PANEL_NAME);
            CleanCorrection();
        }

        public void ShowCorrections(bool[] corrections)
        {
            _spiner.SetActive(false);
        
            for(int i = 0; i < 5; i++)
            {
                _resultsUI[i].gameObject.SetActive(true);
                if (corrections[i])
                {
                    _resultsUI[i].sprite = _tickSprite;
                }
                else
                {
                    _resultsUI[i].sprite = _crossSprite;
                    _recommendButton[i].SetActive(true);
                }
            }
        }

        public void ShowAnswers(string[] answers)
        {
            for (int i = 0; i < _answersUI.Length; i++)
            {
                _answersUI[i].text = answers[i];
            }
        }

        public void SaveMatch()
        {
            OnEndTurn?.Invoke();
        }

        public void ChangeScene()
        {
            _transitionLoading.SlideUp();
            StartCoroutine(WaitingForEndTransitionAnimation());
            
        }
        IEnumerator WaitingForEndTransitionAnimation()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(1,LoadSceneMode.Single);
        }

        public void LoadNextTurn()
        {
            _endRoundPanel.SetActive(true);
            gameObject.SetActive(false);
        }

        public void ShowErrorPanel(string message)
        {
            _errorPanel.SetMessage(message);
            _errorPanel.gameObject.SetActive(true);
        }

        private void CleanCorrection()
        {
            foreach (var go in _recommendButton)
            {
                go.SetActive(false);
            }
            foreach (var img in _resultsUI)
            {
                img.sprite = null;
            }

            foreach (var answer in _answersUI)
            {
                answer.text = "";
            }
        
        }
    }
}
