using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMatchAction
{
    MatchDTO Match { get; set; }

    public int GetCurrentRoundIndex();
    
    bool IsFinished();
}

public class RoundDTO
{
}