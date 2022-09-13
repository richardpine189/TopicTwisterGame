
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

public class SingletonCurrentMatchService : ICurrentMatchService
    {
        public MatchToDeleteRefactor GetActiveMatch()
        {
            return CurrentMatchSingleton.Get();
        }

        public void SetActiveMatch(MatchToDeleteRefactor matchToDeleteRefactor)
        {
            CurrentMatchSingleton.Set(matchToDeleteRefactor);
        }
    }

