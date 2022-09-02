
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class SingletonCurrentMatchService : ICurrentMatchService
    {
        public MatchToDeleteRefacto GetActiveMatch()
        {
            return CurrentMatchSingleton.Get();
        }

        public void SetActiveMatch(MatchToDeleteRefacto matchToDeleteRefacto)
        {
            CurrentMatchSingleton.Set(matchToDeleteRefacto);
        }
    }

