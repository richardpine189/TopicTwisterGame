using Assets.Scripts.Interfaces;
using Assets.Scripts.Presenters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Team8.TopicTwister
{
    public class NewGameView : MonoBehaviour, INewGameView
    {
        [SerializeField]
        private Button newGameButton;

        private NewGamePresenter _presenter;

        public event Action OnNewGameButtonClick;

        void Start()
        {
            _presenter = new NewGamePresenter(this);
            newGameButton.onClick.AddListener(OnNewGameButtonClick.Invoke);
        }
    }
}
