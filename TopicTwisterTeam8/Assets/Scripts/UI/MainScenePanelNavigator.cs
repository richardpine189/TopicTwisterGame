using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainScenePanelNavigator : MonoBehaviour
{
    [Header("Panel")]

    [SerializeField] private RectTransform _mainPanel;
    [SerializeField] private List<RectTransform> _panels;

    private const float ANIMATION_TIME_TO_SLIDING = 0.5f;

    void Start()
    {
        _mainPanel.DOAnchorPos(Vector2.zero, ANIMATION_TIME_TO_SLIDING);
    }

    public void ShowPanel(RectTransform panelToShow)
    {
        foreach(RectTransform rt in _panels)
        {
            Vector2 tempVector = rt.GetComponent<PanelPosition>().PanelInitialPosition;
            rt.DOAnchorPos(tempVector, ANIMATION_TIME_TO_SLIDING);
        }
        panelToShow.DOAnchorPos(Vector2.zero, ANIMATION_TIME_TO_SLIDING);
    }

    public void PlaceHoldingLogOut()
    {
        SceneManager.LoadScene("LoginScene");
    }
}


