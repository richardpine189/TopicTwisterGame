using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

public class IsMatchFinishedAction
{
    public bool Execute(MatchToDeleteRefacto matchToDeleteRefacto)
    {
        if (!matchToDeleteRefacto.rounds.Any(x => x == null) && matchToDeleteRefacto.rounds.All(x => x.roundFinished))
        {
            return true;
        }

        return false;
    }
}
