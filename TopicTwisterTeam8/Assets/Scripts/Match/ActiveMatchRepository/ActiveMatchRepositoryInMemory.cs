using System;
using Models;

public class ActiveMatchRepositoryInMemory : IActiveMatchRepository
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
