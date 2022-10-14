namespace Models.DTO
{
    public class RoundResultsDTO
    {
        public string[] currentCategories;
        public string[] challengerAnswers;
        public string[] opponentAnswers;
        public bool[] challengerResults;
        public bool[] opponentResults;
        public WinnerStatus matchStatus;
    }
}