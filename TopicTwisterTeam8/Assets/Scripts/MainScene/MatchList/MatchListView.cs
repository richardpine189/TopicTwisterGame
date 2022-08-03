using UnityEngine;

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