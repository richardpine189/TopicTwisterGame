using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public interface IMatchAction
{
    Round GetCurrentRound();

    public int GetCurrentRoundIndex();
    
    bool IsFinished();
    public Match GetMatch();

}

