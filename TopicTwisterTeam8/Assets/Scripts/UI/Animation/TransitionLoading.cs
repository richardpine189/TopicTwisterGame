using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitionLoading : MonoBehaviour
{
    [SerializeField] private RectTransform _transform;
    void Start()
    {
        Invoke("ShowOff",1f);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
            ShowOn();
    }

    public void ShowOn()
    {
        _transform.DOAnchorPosY(0,1f);
    }

    void ShowOff()
    {
        _transform.DOAnchorPosY(-2800,1f);
    }
}
