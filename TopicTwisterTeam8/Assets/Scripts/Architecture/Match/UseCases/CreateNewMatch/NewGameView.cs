using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Match.UseCases.CreateNewMatch
{
    public class NewGameView : MonoBehaviour, INewGameView
    {
        public event Action OnNewGameButtonClick;
        [SerializeField]
        private TransitionLoadingView _transitionLoading;
        public void CreateNewMathButton()
        {
            OnNewGameButtonClick?.Invoke();
        }
        public void LoadGameScene()
        {
            _transitionLoading.SlideUp();
            StartCoroutine(WaitingForEndTransitionAnimation());
            
        }
        IEnumerator WaitingForEndTransitionAnimation()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(2,LoadSceneMode.Single);
        }
    }
}

