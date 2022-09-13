using System;
using Models;

public class ActiveMatchInMemory : IActiveMatch
{
    private Match match;

    public Match Match {
        get
        {
            return match;
        }
        set
        {
            match = value;
        }
    }

}
