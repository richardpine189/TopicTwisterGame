namespace Architecture.Match.Domain.DTO
{
    public class RoundResultsDTO
    {
        public string[] currentCategories;
        public string[] challengerAnswers;
        public string[] opponentAnswers;
        public bool[] challengerResults;
        public bool[] opponentResults;
        public char letter;
        public int roundIndex;
        public WinnerStatus matchStatus;
    }
}