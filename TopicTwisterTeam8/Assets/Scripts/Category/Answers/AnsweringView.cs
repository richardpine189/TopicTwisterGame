using System;
using Core.Match.TitleHeaderView;
using TMPro;
using UnityEngine;

public class AnsweringView : MonoBehaviour, IAnsweringView
{
    public event Action<string[]> OnStopClick;
    
    private const string PANEL_NAME = "RESPONDE!";

    [SerializeField]
    private TMP_InputField[] _answers;

    [SerializeField]
    private GameObject _nextPanel;

    void OnEnable()
    {
        for (int i = 0; i < _answers.Length; i++)
        {
            _answers[i].text = "";
        }
        TitleSetName.SendPanelName(PANEL_NAME);
    }

    public void SendAnswers()
    {
        string[] answers = new string[5];

        for(int i = 0; i < 5; i++)
        {
            answers[i] = _answers[i].text;
        }

        OnStopClick.Invoke(answers);
        _nextPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}

