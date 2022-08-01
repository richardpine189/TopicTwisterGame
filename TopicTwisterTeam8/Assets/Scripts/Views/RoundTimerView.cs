using Assets.Scripts.Presenters;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundTimerView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeCounter;

    public event Action<int> OnTimerStop;

    private bool _timerOn = false;
    private float _timeLeft;

    void OnEnable()
    {
        new RoundTimerPresenter(this);

        _timerOn = true;
    }

    void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                
                UpdateTimer(_timeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                _timeLeft = 0;
                _timerOn = false;
            }
        }
    }

    
    private void UpdateTimer(float timeLeft)
    {
        float seconds = Mathf.FloorToInt(timeLeft);

        timeCounter.text = seconds.ToString();
    }

    public void StopTimer()
    {
        _timerOn = false;
        OnTimerStop?.Invoke((int)_timeLeft);
    }

    public void SetTimeLeft(int timeLeft)
    {
        _timeLeft = timeLeft;
    }
}
