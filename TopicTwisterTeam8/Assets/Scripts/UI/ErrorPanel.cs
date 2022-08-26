using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ErrorPanel : MonoBehaviour
{
    [SerializeField]
    private string _sceneToLoad;

    [SerializeField]
    private TextMeshProUGUI _errorText;

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    internal void SetMessage(string message)
    {
        _errorText.text = message;
    }
}
