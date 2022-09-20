using System;
using UnityEngine;
using DG.Tweening;

public class TransitionLoadingView : MonoBehaviour
{
    [SerializeField]
    private RectTransform _transform;
    public static event Action OnShowOnTransition;
    public static event Action OnShowOffTransition;

    private void Awake()
    {
        OnShowOnTransition += SlideUp;
        OnShowOffTransition += SlideDown;
    }

    private void OnEnable()
    {
        OnShowOffTransition?.Invoke();
    }

    private void OnDestroy()
    {
        OnShowOnTransition -= SlideUp;
        OnShowOffTransition -= SlideDown;
    }

    public void SlideUp()
    {
        _transform.DOAnchorPosY(0,0.7f);
    }

    public void SlideDown()
    {
        _transform.DOAnchorPosY(-3400,0.7f);
    }
}
