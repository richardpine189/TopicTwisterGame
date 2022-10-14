using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

