using System.Collections;
using TMPro;
using UnityEngine;

namespace Architecture.Category.UseCases.RecommendWord
{
    public class RecommendView : MonoBehaviour
    {
        [SerializeField] private GameObject _recommendPanel;
        [SerializeField] private TextMeshProUGUI _adviceText;

        public void RecommendButtonClick()
        {
            _recommendPanel.SetActive(true);
        }

        public void Recommend()
        {
            _adviceText.gameObject.SetActive(true);
            StartCoroutine(Waiting());
        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(2);
            _adviceText.gameObject.SetActive(false);
            _recommendPanel.SetActive(false);
        }

        public void CancelButton()
        {
            _recommendPanel.SetActive(false);
        }
    }
}