using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Match.UseCases.CreateNewMatch
{
    public class NewGameView : MonoBehaviour, INewGameView
    {
        public event Action OnNewGameButtonClick;

        public void CreateNewMathButton()
        {
            OnNewGameButtonClick?.Invoke();
        }
        public void LoadGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}

