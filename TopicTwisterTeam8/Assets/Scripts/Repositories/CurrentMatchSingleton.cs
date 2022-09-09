using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

public sealed class CurrentMatchSingleton
    {
        private CurrentMatchSingleton() { }

        private static MatchToDeleteRefacto _currentMatchToDeleteRefacto;

        public static MatchToDeleteRefacto Get()
        {
            return _currentMatchToDeleteRefacto;
        }

        public static void Set(MatchToDeleteRefacto matchToDeleteRefacto)
        {
            _currentMatchToDeleteRefacto = matchToDeleteRefacto;
        }
    }

