using System;

public class SignInPresenter
{
    private ISignInView _view;
    private ISignInUseCase _signInUseCase;

    public SignInPresenter(ISignInView signInView, ISignInUseCase signInUseCase)
    {
        _view = signInView;
        _signInUseCase = signInUseCase;
        _view.OnSignInTrigger += SignIn;
    }

    ~SignInPresenter()
    {
        _view.OnSignInTrigger -= SignIn;
    }

    private async void SignIn(string username, string email)
    {
        if (String.IsNullOrEmpty(username))
        {
            _view.ShowErrorMessage("No se ha envíado un nombre de usuario.");
        }
        else if (String.IsNullOrEmpty(email))
        {
            _view.ShowErrorMessage("No se ha envíado un email valido.");
        }
        else
        {
            try
            {
                await _signInUseCase.Invoke(username, email);
            }
            catch (Exception e)
            {
                _view.ShowErrorMessage(e.Message);
            }
        }
    }
}