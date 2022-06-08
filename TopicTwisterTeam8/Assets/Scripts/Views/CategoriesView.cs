using Assets.Scripts.Actions;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Presenters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Team8.TopicTwister.Assets.Scripts.Views
{
    public class CategoriesView : MonoBehaviour, ILetterView
    {
        public event Action OnSpinClick;

        [SerializeField]
        private TMP_Text _letter;

        [SerializeField]
        private TMP_Text _countdownText;

        [SerializeField]
        private Button _getLetterButton;

        [SerializeField]
        private TMP_Text[] _categories;

        [SerializeField]
        private GameObject _nextPanel;
        [SerializeField]
        private LetterSO _letterSO;

        private LetterPresenter _presenter;

        private void Start()
        {
            _presenter = new LetterPresenter(this, new RandomLetterGetter(), new HardCodedCategoriesGetter());
            _getLetterButton.onClick.AddListener(OnSpinClick.Invoke);
            
        }

        public void ShowLetter(char letter)
        {

            _letter.text = letter.ToString();
            _letter.gameObject.SetActive(true);
            _getLetterButton.gameObject.SetActive(false);
            _letterSO.letter = letter; // SAVING LETTER
            StartCoroutine(CoutdownAnimation());
        }

        private IEnumerator CoutdownAnimation()
        {
            _countdownText.gameObject.SetActive(true);

            for(int i = 3; i > 0; i--)
            {
                _countdownText.text = i.ToString();
                yield return new WaitForSeconds(1);
            }

            _nextPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }

        public void ShowCategories(string[] categories)
        {
            for(int i = 0; i < 5; i++)
            {
                _categories[i].text = categories[i];
            }
        }
    }
}
