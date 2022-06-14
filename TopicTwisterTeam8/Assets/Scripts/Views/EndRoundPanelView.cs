using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Team8.TopicTwister
{
    public class EndRoundPanelView : MonoBehaviour, IEndRoundView
    {
        [SerializeField]
        private TextMeshProUGUI[] _categories;

        [SerializeField]
        private TMP_InputField[] _challengerAnswers;

        [SerializeField]
        private TMP_InputField[] _oponentAnswers;

        [SerializeField]
        private Image[] _challengerResult;

        [SerializeField]
        private Image[] _oponentResult;

        private EndRoundPresenter _endRoundPresenter;

        private void Start()
        {
            _endRoundPresenter = new EndRoundPresenter(this);
        }
        void IEndRoundView.ShowCategories(string[] categories)
        {
            throw new System.NotImplementedException();
        }

        void IEndRoundView.ShowChallengerAnswersAndResult(string[] categories, bool[] results)
        {
            throw new System.NotImplementedException();
        }

        void IEndRoundView.ShowOponentAnswersAndResult(string[] categories, bool[] results)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
