﻿using Assets.Scripts.Actions;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Presenters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Team8.TopicTwister
{
    public class LoadingGameView : MonoBehaviour, ILoadingGameView
    {
        [SerializeField]
        private TMP_Text _playerName;

        [SerializeField]
        private TMP_Text _opponentName;

        [SerializeField]
        private TMP_Text _loadingText;

        [SerializeField]
        private GameObject _versusImage;

        [SerializeField]
        private GameObject _nextPanel;

        private LoadingGamePresenter _presenter;

        private void Start()
        {
            StartCoroutine(MainMethod());
        }

        private IEnumerator MainMethod()
        {
            // Simulated loading, change name, refactor
            StartCoroutine(LoadingAnimation());

            yield return new WaitForSeconds(3.0f);

            // Should the matchcreator be instantiated here? In the view file?
            _presenter = new LoadingGamePresenter(this, new HardcodedMatchActions());

            Invoke("ChangePanel", 3.0f);
        }

        public void ShowPlayersInfo(string playerName, string opponentName)
        {
            _playerName.text = playerName;
            _opponentName.text = opponentName;
        }

        private IEnumerator LoadingAnimation()
        {
            _loadingText.gameObject.SetActive(true);
            _versusImage.SetActive(false);

            for (int i = 0; i < 10; i++)
            {
                _loadingText.text = "Loading" + (i % 3 == 0 ? "." : (i % 3 == 1 ? ".." : "..."));
                yield return new WaitForSeconds(0.3f);
            }

            _loadingText.gameObject.SetActive(false);
            _versusImage.SetActive(true);
        }

        private void ChangePanel()
        {
            _nextPanel.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }
}