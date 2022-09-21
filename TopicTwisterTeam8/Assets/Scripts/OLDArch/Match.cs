
namespace Models
{
    public class Match 
    {
        public int idMatch;
        public string challengerName;
        public string opponentName;
        public int currentRound;
        
        public string[] currentAnswers;
        public string[] currentCategories;
        public bool[] currentResults;
        public char? currentLetter;
        public int roundTimeLeft = 60;
        
        public readonly Round round= new Round();
        /*
        public readonly MatchStat matchState= new MatchState();
        */
        public bool isChallengerTurn;
        public bool isMatchFinished;
        
    }

    public class MatchState
    {
        public int currentRound;
        public bool isChallengerTurn;
        public bool isMatchFinished;
    }
    public class Round
    {
        /*public Round(string[] currentAnswers, string[] currentCategories, bool[] currentResults, char? currentLetter, int roundTimeLeft = 60)
        {
            CurrentAnswers = currentAnswers;
            CurrentCategories = currentCategories;
            CurrentResults = currentResults;
            CurrentLetter = currentLetter;
            RoundTimeLeft = roundTimeLeft;
        }*/

        public string[] CurrentAnswers;
        public string[] CurrentCategories;
        public bool[] CurrentResults;
        public char? CurrentLetter;
        public int RoundTimeLeft = 60;
    }
}
