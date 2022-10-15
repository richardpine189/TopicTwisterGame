using System;

public interface ISignInView
{
    public void ShowMessage(string message);
 
    void GoToLogIn();

    event Action<string, string> OnSignInTrigger;
}