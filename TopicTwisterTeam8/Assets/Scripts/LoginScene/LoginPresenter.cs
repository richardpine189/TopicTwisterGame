using System;
using Zenject;
public class LoginPresenter : IInitializable, IDisposable
    {
        [Inject] private ILoginView _view;
        [Inject] private ILoginGetUserAction _loginAction;

        public void Initialize()
        {
            _view.OnLoginTrigger += LogIn;

        }

        public void Dispose()
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

