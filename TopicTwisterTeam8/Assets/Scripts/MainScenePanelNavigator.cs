using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Team8.TopicTwister
{
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
            }
            panelToShow.DOAnchorPos(Vector2.zero, ANIMATION_TIME_TO_SLIDING);
        }

    }

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
}

