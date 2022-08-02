using System;
public interface ILoginView
    {
        event Action<string> OnLoginTrigger;
        void ShowErrorMessage(string message);
        void LoadMainScene();
    }

