using TMPro;
using UnityEngine;

namespace Architecture.Match.MatchHeader.TitleHeaderView
{
    public class TitleHeaderView : MonoBehaviour, ITitleHeaderView
    {
        [Header("PanelTitle")] [SerializeField]
        private TextMeshProUGUI _panelTitleText;
        
        public void SetPanelTitleText(string text)
        {
            _panelTitleText.text = text;
        }   
    }
}