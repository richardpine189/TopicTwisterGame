using UnityEngine;

public class MatchListView : MonoBehaviour, IMatchListView
{
    [SerializeField]
    private GameObject matchUIPrefab;
    
    public void CreateMatchUI(MatchViewModel matchViewModel)
    {
        GameObject go = Instantiate(matchUIPrefab, new Vector2(0, 0), Quaternion.identity) as GameObject;
        go.transform.SetParent(this.transform, false);
        go.GetComponent<OngoingMatchView>().SetFields(matchViewModel);
    }
}







