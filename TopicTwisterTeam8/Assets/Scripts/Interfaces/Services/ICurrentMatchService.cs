﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public interface ICurrentMatchService
    {
        void SetActiveMatch(MatchToDeleteRefacto matchToDeleteRefacto);

        MatchToDeleteRefacto GetActiveMatch();
    }

