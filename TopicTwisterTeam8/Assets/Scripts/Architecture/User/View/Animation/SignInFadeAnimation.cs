using DG.Tweening;
using UnityEngine;

namespace Architecture.User.View.Animation
{
    public class SignInFadeAnimation : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _logInPanel;

        [SerializeField]
        private CanvasGroup _signInPanel;

        [SerializeField]
        private float _animationTime;

        public void ShowLogIn()
        {
            Sequence signInSequence = DOTween.Sequence();

            signInSequence.Append(_signInPanel.DOFade(0, _animationTime));
            signInSequence.Append(_logInPanel.DOFade(1, _animationTime)).OnComplete(() => SetActive(_logInPanel, _signInPanel));
        }

        public void ShowSignIn()
        {
            Sequence signInSequence = DOTween.Sequence();

            signInSequence.Append(_logInPanel.DOFade(0, _animationTime));
            signInSequence.Append(_signInPanel.DOFade(1, _animationTime)).OnComplete(() => SetActive(_signInPanel, _logInPanel));
        }

        private void SetActive(CanvasGroup panelToActive, CanvasGroup panelToDeactive)
        {
            panelToActive.blocksRaycasts = true;
            panelToActive.interactable = true;
            panelToDeactive.blocksRaycasts = false;
            panelToDeactive.interactable = false;
        }
    }
}
