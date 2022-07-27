using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IsMatchFinishedAction
{
    public bool Execute(Match match)
    {
        if (!match.rounds.Any(x => x == null) && match.rounds.All(x => x.roundFinished))
        {
            return true;
        }

        return false;
    }
}
