using TMPro;
using UnityEngine;

namespace Architecture.Match.MatchHeader.Letter
{
    public class MatchHeaderLetterView : MonoBehaviour, IMatchHeaderLetterView
    
    {
        [SerializeField] private GameObject _letterContainer;
        [SerializeField] private TextMeshProUGUI _letter;
        
        public void SetRoundLetter(string letter)
        {
            _letter.text = letter;
            _letterContainer.SetActive(true);
        }

        public void HideLetter()
        {
            _letterContainer.SetActive(false);
        }
    }
    
}