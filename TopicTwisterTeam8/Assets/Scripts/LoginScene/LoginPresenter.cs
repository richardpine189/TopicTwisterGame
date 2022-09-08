using System;
using UnityEngine;
public class LoginPresenter 
    {
        private ILoginView _view;
        private ILoginGetUserAction _loginAction;
        
        public LoginPresenter(ILoginView loginView, ILoginGetUserAction loginAction)
        {
            _view = loginView;
            _loginAction = loginAction;
            _view.OnLoginTrigger += LogIn;
        }

        ~LoginPresenter()
        {
            _view.OnLoginTrigger -= LogIn;
        }

        private async void LogIn(string username)
        {
            if (!String.IsNullOrEmpty(username))
            {
                try
                {
                    await _loginAction.Invoke(username);
                    _view.LoadMainScene();
                }
                catch (Exception e)
                {
                    _view.ShowErrorMessage(e.Message);
                }
            }
            else
            {
                _view.ShowErrorMessage("No se ha envíado un nombre de usuario");
            }
        }

    }

