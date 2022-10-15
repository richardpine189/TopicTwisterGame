using System;

namespace Architecture.User.View
{
    public interface ILoginView
    {
        event Action<string> OnLoginTrigger;
        void ShowErrorMessage(string message);
        void LoadMainScene();
    }
}

