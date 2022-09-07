using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameView : MonoBehaviour, INewGameView
{
    [SerializeField]
    private Button newGameButton;
    public event Action OnNewGameButtonClick;

    void Start()
    {
        newGameButton.onClick.AddListener(OnNewGameButtonClick.Invoke);
    }
}

