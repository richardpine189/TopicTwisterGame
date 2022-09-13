using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

public class IsMatchFinishedAction
{
    public bool Execute(MatchToDeleteRefactor matchToDeleteRefactor)
    {
        if (!matchToDeleteRefactor.rounds.Any(x => x == null) && matchToDeleteRefactor.rounds.All(x => x.roundFinished))
        {
            return true;
        }

        return false;
    }
}
