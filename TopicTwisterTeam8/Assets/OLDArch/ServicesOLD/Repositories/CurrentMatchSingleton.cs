
using Models;

public sealed class CurrentMatchSingleton
    {
        private CurrentMatchSingleton() { }

        private static MatchToDeleteRefactor _currentMatchToDeleteRefactor;

        public static MatchToDeleteRefactor Get()
        {
            return _currentMatchToDeleteRefactor;
        }

        public static void Set(MatchToDeleteRefactor matchToDeleteRefactor)
        {
            _currentMatchToDeleteRefactor = matchToDeleteRefactor;
        }
    }

