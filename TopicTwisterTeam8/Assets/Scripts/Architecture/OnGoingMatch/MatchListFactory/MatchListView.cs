using Architecture.OnGoingMatch.Card;
using UnityEngine;

namespace Architecture.OnGoingMatch.MatchListFactory
{
    public class MatchListView : MonoBehaviour, IMatchListView
    {
        [SerializeField]
        private GameObject matchUIPrefab;
    
        public IOngoingMatchView CreateMatchCard()
        {
            GameObject go = Instantiate(matchUIPrefab, new Vector2(0, 0), Quaternion.identity);
            go.transform.SetParent(this.transform, false);
            return go.GetComponent<IOngoingMatchView>();
        }
    }
}