using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;


public class LoginView : MonoBehaviour, ILoginView
    {
        // Development URL
        //private static readonly string baseURL = @"http://localhost:8080";

        [SerializeField]
        private TMP_InputField _usernameInputField;

        [SerializeField]
        private GameObject _errorPanel;

        private LoginPresenter _presenter;

        public event Action<string> OnLoginTrigger;

        private void Start()
        {
            _presenter = new LoginPresenter(this);
        }

        public void LoginButton()
        {
            string username = _usernameInputField.text;

            OnLoginTrigger.Invoke(username);
        }

        public void ShowErrorMessage(string message)
        {
            //Debug.Log(message);

            (_errorPanel.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text).text = message;
            _errorPanel.SetActive(true);
        }

        public void LoadMainScene()
        {
            SceneManager.LoadScene("MainScene");
        }
    }

