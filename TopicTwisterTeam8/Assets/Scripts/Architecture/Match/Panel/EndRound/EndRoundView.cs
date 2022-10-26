using System;
using Architecture.Match.Domain.DTO;
using Architecture.Match.MatchHeader.TitleHeaderView;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Architecture.Match.Panel.EndRound
{
    public class EndRoundView : MonoBehaviour, IEndRoundView
    {
        public event Action OnSetRoundResults;
        public event Action OnSetLetterForRoundResults;
        public event Action OnSetRoundNumberForRoundResults;
        public event Action OnUpdateRoundNumber;
    
        private const string PANEL_NAME = "FINAL DE RONDA";
    
        [SerializeField]
        private GameObject _header;
    
        [SerializeField]
        private TextMeshProUGUI[] _categories;

        [SerializeField]
        private TextMeshProUGUI[] _challengerAnswers;

        [SerializeField]
        private TextMeshProUGUI[] _opponentAnswers;

        [SerializeField]
        private Image[] _challengerResult;

        [SerializeField]
        private Image[] _opponentResult;

        [SerializeField]
        private Sprite _tickSprite;

        [SerializeField]
        private Sprite _crossSprite;

        [SerializeField]
        private GameObject _endgamePanel;

        [SerializeField]
        private GameObject _categoriesPanel;
    
        [SerializeField]
        private GameObject _nextRoundButton;
    
        [SerializeField]
        private GameObject _backToMainButton;

        void OnEnable()
        {
            _header.SetActive(true);
            _nextRoundButton.GetComponent<Button>().enabled = true;
            TitleSetName.SendPanelName(PANEL_NAME);
            OnSetRoundResults?.Invoke();
            CleanTextField(_challengerAnswers);
            CleanTextField(_opponentAnswers);
            CleanTextField(_categories);
            CleanResults(_challengerResult);
            CleanResults(_opponentResult);
        }

        private void CleanResults(Image[] imagesCorrection)
        {
            foreach (var image in imagesCorrection)
            {
                image.sprite = null;
            }
        }
        private void CleanTextField(TextMeshProUGUI[] text)
        {
            foreach (var textField in text)
            {
                textField.text = "";
            }
        }
        public void ShowCategories(string[] categories)
        {
            for (int i = 0; i < categories.Length; i++)
            {
                _categories[i].text = categories[i];
            }
        }

        public void ShowLoggedPlayerAnswersAndResult(string[] answers, bool[] results)
        {
            for (int i = 0; i < answers.Length; i++)
            {
                _challengerAnswers[i].text = answers[i];

                if(results[i])
                {
                    _challengerResult[i].sprite = _tickSprite;
                }
                else
                {
                    _challengerResult[i].sprite = _crossSprite;
                }
            }
        }

        public void ShowSecondPlayerAnswersAndResult(string[] answers, bool[] results)
        {
            for (int i = 0; i < answers.Length; i++)
            {
                _opponentAnswers[i].text = answers[i];

                if (results[i])
                {
                    _opponentResult[i].sprite = _tickSprite;
                }
                else
                {
                    _opponentResult[i].sprite = _crossSprite;
                }
            }
        }

        public void ChangePanel()
        {
            _nextRoundButton.GetComponent<Button>().enabled = false;
            _categoriesPanel.SetActive(true);
            OnUpdateRoundNumber?.Invoke();
            OnSetRoundNumberForRoundResults?.Invoke();
            gameObject.SetActive(false);
        }

        public void ShowEndGamePanel(WinnerStatus winner)
        {
            TMP_Text text = _endgamePanel.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text;
            //text.text = challengerWon ? "Ganaste!" : "Perdiste :(";
            _nextRoundButton.SetActive(false);
            _backToMainButton.SetActive(true);
        }

        public void SetLetterForHeader()
        {
            OnSetLetterForRoundResults?.Invoke();
            OnSetRoundNumberForRoundResults?.Invoke();
        }

        public void BackToMain()
        {
            _backToMainButton.GetComponent<Button>().enabled = false;
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        public void ChangeButtons()
        {
            _backToMainButton.SetActive(true);
            _nextRoundButton.SetActive(false);
        }
    }
}

