using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Team8.TopicTwister
{
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

        public void LoadMainScene(UserDTO user)
        {
            // TODO save user

            SceneManager.LoadScene("MainScene");
        }
    }

    class LoginPresenter
    {
        private ILoginView _view;
        private LoginAction _loginAction;

        public LoginPresenter(ILoginView view)
        {
            _view = view;
            _view.OnLoginTrigger += LogIn;
            _loginAction = new LoginAction();
        }

        private async void LogIn(string username)
        {
            if(!String.IsNullOrEmpty(username))
            {
                try
                {
                    string userJson = await _loginAction.Invoke(username);

                    UserDTO user = _loginAction.UserJsonToDTO(userJson);

                    _view.LoadMainScene(user);
                }
                catch(Exception e)
                {
                    _view.ShowErrorMessage(e.Message);
                }
            }
            else
            {
                _view.ShowErrorMessage("No se ha envíado un nombre de usuario");
            }
        }

        ~LoginPresenter(){ _view.OnLoginTrigger -= LogIn; }
    }

    public interface ILoginView
    {
        event Action<string> OnLoginTrigger;

        void ShowErrorMessage(string message);

        void LoadMainScene(UserDTO user);
    }

    class LoginAction
    {
        // This should be in a general config file for the whole project
        private static readonly HttpClient client = new HttpClient();

        // Development URL
        private static readonly string baseURL = @"http://localhost:8080";

        public async Task<string> Invoke(string username)
        {
            var values = new Dictionary<string, string>
            {
                { "userName", username }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(baseURL + "/user/logIn", content);

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpRequestException("User not found in databse");
            }

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public UserDTO UserJsonToDTO(string userJson)
        {
            return JsonConvert.DeserializeObject<UserDTO>(userJson);
        }
    }
}
