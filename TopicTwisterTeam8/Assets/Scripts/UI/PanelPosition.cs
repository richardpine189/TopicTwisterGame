using UnityEngine;
public class PanelPosition : MonoBehaviour
{
    private Vector2 _panelInitialPosition;
    private RectTransform _panelTransform;

    public Vector2 PanelInitialPosition { get => _panelInitialPosition; private set => _panelInitialPosition = value; }

    private void Awake()
    {
        _panelTransform = GetComponent<RectTransform>();
        _panelInitialPosition = _panelTransform.anchoredPosition;
    }
}