using Architecture.OnGoingMatch.Card;

namespace Architecture.OnGoingMatch.MatchListFactory
{
    public interface IMatchListView
    {
        IOngoingMatchView CreateMatchCard();
    }
}