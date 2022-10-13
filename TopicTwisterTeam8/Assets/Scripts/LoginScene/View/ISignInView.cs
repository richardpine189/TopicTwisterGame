using System;

public interface ISignInView
{
    public void ShowErrorMessage(string message);

    event Action<string, string> OnSignInTrigger;
}