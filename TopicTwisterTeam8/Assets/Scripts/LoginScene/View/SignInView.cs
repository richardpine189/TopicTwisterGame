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
    private GameObject _errorPanel;

    [SerializeField]
    private GameObject _button;

    [SerializeField]
    private GameObject _spiner;

    public event Action<string, string> OnSignInTrigger;

    public void SignIn()
    {
        string username = _usernameInputField.text;
        string email = _emailInputField.text;

        OnSignInTrigger?.Invoke(username, email);
        _button.SetActive(false);
        _spiner.SetActive(true);
    }

    public void ShowErrorMessage(string message)
    {
        (_errorPanel.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text).text = message;
        _spiner.SetActive(false);
        _errorPanel.SetActive(true);
        _button.SetActive(true);
    }
}