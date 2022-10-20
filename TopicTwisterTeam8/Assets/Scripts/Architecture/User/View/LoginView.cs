using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.User.View
{
    public class LoginView : MonoBehaviour, ILoginView
    {
        [SerializeField]
        private TMP_InputField _usernameInputField;

        [SerializeField]
        private GameObject _errorPanel;

        [SerializeField]
        private GameObject _button;

        [SerializeField]
        private GameObject _spiner;

        [SerializeField]
        private TransitionLoadingView _transitionLoadingView;
        
        public event Action<string> OnLoginTrigger;

        public void LoginButton()
        {
            string username = _usernameInputField.text;

            _spiner.SetActive(true);
            _button.SetActive(false);
            OnLoginTrigger.Invoke(username);
        }

        public void ShowErrorMessage(string message)
        {
            (_errorPanel.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text).text = message;
            _spiner.SetActive(false);
            _errorPanel.SetActive(true);
            _button.SetActive(true);
        }

        public void LoadMainScene()
        {
            _transitionLoadingView.SlideUp();

            StartCoroutine(WaitAndChangeScene());
        }

        private IEnumerator WaitAndChangeScene()
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("MainScene"); //HardCoding
        }
    }
}

