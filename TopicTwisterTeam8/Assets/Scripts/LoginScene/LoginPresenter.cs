using System;
using UnityEngine;
public class LoginPresenter 
    {
        private ILoginView _view;
        private ILoginGetUserUseCase _loginUseCase;
        
        public LoginPresenter(ILoginView loginView, ILoginGetUserUseCase loginUseCase)
        {
            _view = loginView;
            _loginUseCase = loginUseCase;
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
                    await _loginUseCase.Invoke(username);
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

