public class Match
{
    public int? id;
    public User challenger;
    public User opponent;
    public Round[] rounds = new Round[3];
    public bool isChallengerTurn = true;

}

public class Round
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
