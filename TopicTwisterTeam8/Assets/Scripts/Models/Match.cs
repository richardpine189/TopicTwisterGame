namespace TopicTwister.Assets.Scripts.Models
{
    public class Match
    {
        public int? id;
        public User challenger;
        public User opponent;
        public Round[] rounds = new Round[3];
    }

    public class Round
    {
        public char letter;
        public string[] assignedCategoryNames;
        public string[] challengerAnswers;
        public string[] opponentAnswers;
    }
}