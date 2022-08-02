using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OngoingMatchPresenter
{
    
    public void SaveCurrentMatch(int matchId)
    {
        SetActiveMatch action = new SetActiveMatch();
        action.Execute(matchId);
    }

    /*public void BotResolveRound(int matchId, ICategoriesGetter categoriesGetter)
    {
        SetBotInMatchAction botAction = new SetBotInMatchAction(matchId, categoriesGetter);
        botAction.Execute();
    }
    */
}