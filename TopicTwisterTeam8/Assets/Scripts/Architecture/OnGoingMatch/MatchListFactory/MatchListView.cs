using System;
using System.Collections;
using Architecture.OnGoingMatch.Card;
using UnityEngine;
using DG.Tweening;

namespace Architecture.OnGoingMatch.MatchListFactory
{
    public class MatchListView : MonoBehaviour, IMatchListView
    {
        public event Action OnUpdateMatchList;
        [SerializeField]
        private GameObject matchUIPrefab;

        [SerializeField]
        private GameObject _reLoadImage;
    
        public IOngoingMatchView CreateMatchCard()
        {
            GameObject go = Instantiate(matchUIPrefab, new Vector2(0, 0), Quaternion.identity);
            go.transform.SetParent(this.transform, false);
            return go.GetComponent<IOngoingMatchView>();
        }

        public void ReLoadOnGoingMatch()
        {
            var cards = GameObject.FindGameObjectsWithTag("Card");
            foreach (var card in cards)
            {
                Destroy(card);
            }

            StartCoroutine(AnimationReload());
            OnUpdateMatchList?.Invoke();
        }

        IEnumerator AnimationReload()
        {
            _reLoadImage.transform.DORotate(Vector3.back * 360, 1f, RotateMode.FastBeyond360);
            yield return new WaitForSeconds(1f);
        }
    }
}