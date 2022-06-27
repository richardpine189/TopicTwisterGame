
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class SetActiveMatch
{
    IMatchRepository _matchRepository;
    ICurrentMatchService _matchService;

    public SetActiveMatch()
    {
        _matchRepository = ServiceLocator.Instance.GetService<IMatchRepository>();
        _matchService = new SingletonCurrentMatchService();
    }

    public void Execute(int id)
    {
        List<Match> matches = _matchRepository.GetMatches();
        Match activeMatch = matches.Find(m => m.id == id);
        _matchService.SetActiveMatch(activeMatch);
    }

    public void RemoveActiveMatch()
    {
        _matchService.SetActiveMatch(null);
    }
}

public class SetBotInMatchAction
{
    private int _matchId;
    private IMatchRepository _matchRepository;
    private ICategoriesRepository _categoriesRepository;
    public SetBotInMatchAction(int matchId, ICategoriesRepository categoriesRepository)
    {
        _matchId = matchId;
        _categoriesRepository = categoriesRepository;
        _matchRepository = ServiceLocator.Instance.GetService<IMatchRepository>();
    }

    public void Execute()
    {
        ILetterGetter letterGeter = new RandomLetterGetter();
        List<Match> matches = _matchRepository.GetMatches();
        Match activeMatch = matches.Find(m => m.id == _matchId);
        bool isPlayerTurn = (activeMatch.rounds.Any(x => !x.roundFinished) ? activeMatch.rounds.First(x => !x.roundFinished).opponentAnswers != null : true);
        if (isPlayerTurn)
            return;
        SubExecute(activeMatch);
        
        Round newCurrentRound = new Round();
        newCurrentRound.letter = letterGeter.GetLetter();
        newCurrentRound.assignedCategoryNames = _categoriesRepository.GetCategories(5).Select(x => x.Name).ToArray();
        int indexRound = 0;
        for(int i=0; i< activeMatch.rounds.Length;i++)
        {
            if(activeMatch.rounds[i] == null)
            {
                indexRound = i;
                break;
            }
        }
        activeMatch.rounds[indexRound] = newCurrentRound;
        SubExecute(activeMatch);
    }

    private void SubExecute(Match match)
    {
        
        //Referenciar a una Clase MatchAction
        Round currentRound = match.rounds.First(r => r.roundFinished == false && r != null);
        CategoriesGetter categoriesGetter = new CategoriesGetter(_categoriesRepository);
        var categories = _categoriesRepository.GetCategories();
        string[] currentCatergories = currentRound.assignedCategoryNames;
        string[] answers = new string[5];
        bool[] result = new bool[5];
        for (int i = 0; i < 5; i++)
        {
            Category category = categories.First(c => c.Name == currentCatergories[i]);
            Random random = new Random();
            int index = random.Next(0, category.Words.Count);
            answers[i] = category.Words[index];
            result[i] = category.ExisistInCategory(answers[i], currentRound.letter);
        }
        currentRound.opponentAnswers = answers;
        currentRound.opponentResult = result;
        currentRound.roundFinished = true;
        _matchRepository.SaveMatch(match);
    }
}

