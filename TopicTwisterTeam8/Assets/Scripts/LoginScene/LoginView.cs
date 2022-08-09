using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginView : MonoBehaviour, ILoginView
    {
        [SerializeField]
        private TMP_InputField _usernameInputField;

        [SerializeField]
        private GameObject _errorPanel;

        [SerializeField] private GameObject _button;
        [SerializeField] private GameObject _spiner;
        public event Action<string> OnLoginTrigger;

        public void LoginButton()
        {
            string username = _usernameInputField.text;

            OnLoginTrigger.Invoke(username);
            _button.SetActive(false);
            _spiner.SetActive(true);
        }

        public void ShowErrorMessage(string message)
        {
            (_errorPanel.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text).text = message;
            _errorPanel.SetActive(true);
        }

        public void LoadMainScene()
        {
            SceneManager.LoadScene("MainScene");
        }
    }

