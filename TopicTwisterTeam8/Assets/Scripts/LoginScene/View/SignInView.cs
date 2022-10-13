using System;
using TMPro;
using UnityEngine;

public class SignInView : MonoBehaviour, ISignInView
{
    [SerializeField]
    private TMP_InputField _usernameInputField;

    [SerializeField]
    private TMP_InputField _emailInputField;

    [SerializeField]
    private GameObject _notificationPanel;

    [SerializeField]
    private GameObject _button;

    [SerializeField]
    private GameObject _spiner;

    [SerializeField]
    private SignInFadeAnimation _fadeAnimation;

    public event Action<string, string> OnSignInTrigger;

    public void SignIn()
    {
        string username = _usernameInputField.text;
        string email = _emailInputField.text;

        _spiner.SetActive(true);
        _button.SetActive(false);
        OnSignInTrigger?.Invoke(username, email);
    }

    public void GoToLogIn()
    {
        _fadeAnimation.ShowLogIn();
    }

    public void ShowMessage(string message)
    {
        (_notificationPanel.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text).text = message;
        _spiner.SetActive(false);
        _notificationPanel.SetActive(true);
        _button.SetActive(true);
    }

}