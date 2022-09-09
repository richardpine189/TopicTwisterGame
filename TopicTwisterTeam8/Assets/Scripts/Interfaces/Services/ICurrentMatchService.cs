using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


public interface ICurrentMatchService
    {
        void SetActiveMatch(MatchToDeleteRefacto matchToDeleteRefacto);

        MatchToDeleteRefacto GetActiveMatch();
    }

