using System;
using System.Collections;
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
        StartCoroutine(WaitForChargeData());
        
    }

    private void OnDestroy()
    {
        OnShowOnTransition -= SlideUp;
        OnShowOffTransition -= SlideDown;
    }

    public void SlideUp()
    {
        _transform.DOAnchorPosY(0,0.9f);
    }

    public void SlideDown()
    {
        _transform.DOAnchorPosY(-2600,0.9f);
    }

    public IEnumerator WaitForChargeData()
    {
        yield return new WaitForSeconds(1);
        OnShowOffTransition?.Invoke();
    }
}
