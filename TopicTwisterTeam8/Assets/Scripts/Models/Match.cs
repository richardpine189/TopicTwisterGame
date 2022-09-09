
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

        public bool isChallengerTurn;
        public bool isMatchFinished;
    }
}
