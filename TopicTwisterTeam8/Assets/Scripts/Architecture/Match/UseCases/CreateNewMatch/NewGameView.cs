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
        public void StartGame()
        {
            _transitionLoading.SlideUp();
            StartCoroutine(WaitingForEndTransitionAnimation());
            
        }
        IEnumerator WaitingForEndTransitionAnimation()
        {
            yield return new WaitForSeconds(1f); //TODO : Refactor Animation
            SceneManager.LoadScene(2,LoadSceneMode.Single);
        }
    }
}

