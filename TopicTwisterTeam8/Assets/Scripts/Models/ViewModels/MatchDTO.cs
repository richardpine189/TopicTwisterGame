using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MatchDTO
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