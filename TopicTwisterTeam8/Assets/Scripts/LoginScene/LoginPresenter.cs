using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LoginScene
{
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
            if (!String.IsNullOrEmpty(username))
            {
                try
                {
                    string userJson = await _loginAction.Invoke(username);

                    UserDTO user = _loginAction.UserJsonToDTO(userJson);

                    _view.LoadMainScene(user);
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

        ~LoginPresenter() { _view.OnLoginTrigger -= LogIn; }
    }
}
