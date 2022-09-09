namespace Models
{
    public class MatchToDeleteRefacto
    {
        public int? id;
        public User challenger;
        public User opponent;
        public RoundToDeleteRefactor[] rounds = new RoundToDeleteRefactor[3];
        public bool isChallengerTurn = true;
    }

    public class RoundToDeleteRefactor
    {
        public char? letter;
        public string[] assignedCategoryNames;
        public string[] challengerAnswers;
        public string[] opponentAnswers;
        public bool[] challengerResult;
        public bool[] opponentResult;
        public bool roundFinished = false;
        public int timer = 60;
    }
}