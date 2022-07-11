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

    private bool TimerOn = false;
    public float TimeLeft;

    void OnEnable()
    {
        new RoundTimerPresenter(this);

        TimerOn = true;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
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
        TimerOn = false;

        OnTimerStop?.Invoke((int)TimeLeft);
    }
}
