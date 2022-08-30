using System;
using System.Collections.Generic;
using System.Linq;

public class SetActiveMatch
{
    IMatchRepository _matchRepository;
    ICurrentMatchService _matchService;

    public SetActiveMatch()
    {
        _matchRepository = ServiceLocator.Instance.GetService<IMatchRepository>();
        _matchService = new SingletonCurrentMatchService();
    }

    public async void Execute(int id)
    {
        List<Match> matches = await _matchRepository.GetMatches();
        Match activeMatch = matches.Find(m => m.id == id);
        _matchService.SetActiveMatch(activeMatch);
    }

    public void RemoveActiveMatch()
    {
        _matchService.SetActiveMatch(null);
    }
}

/* SKYNET 0.1
public class SetBotInMatchAction
{
    private int _matchId;
    private IMatchRepository _matchRepository;
    private ICategoriesGetter _categoriesGetter;
    public SetBotInMatchAction(int matchId, ICategoriesGetter categoriesGetter)
    {
        _matchId = matchId;
        _categoriesGetter = categoriesGetter;
        _matchRepository = ServiceLocator.Instance.GetService<IMatchRepository>();
    }

    public async void Execute()
    {
        ILetterGetter letterGeter = new RandomLetterGetter();
        List<Match> matches = _matchRepository.GetMatches();
        Match activeMatch = matches.Find(m => m.id == _matchId);
        bool isPlayerTurn = (activeMatch.rounds.Any(x => !x.roundFinished) ? activeMatch.rounds.First(x => !x.roundFinished).opponentAnswers != null : true);
        if (isPlayerTurn)
            return;
        Round tempRound = SubExecute(activeMatch);
        int indexRound = 0;
        for (int i = 0; i < activeMatch.rounds.Length; i++)
        {
            if (activeMatch.rounds[i] != null && activeMatch.rounds[i].roundFinished == false)
            {
                indexRound = i;
                break;
            }
        }
        tempRound.roundFinished = true;
        
        
       
        activeMatch.rounds[indexRound] = tempRound;
        _matchRepository.SaveMatch(activeMatch);
        if (indexRound == 2) return;
        Round newCurrentRound = new Round();
        newCurrentRound.letter = letterGeter.GetLetter();
        newCurrentRound.assignedCategoryNames = await _categoriesGetter.GetCategories(5);
        
        for(int i=0; i< activeMatch.rounds.Length;i++)
        {
            if(activeMatch.rounds[i] == null)
            {
                indexRound = i;
                break;
            }
        }
        Random timer = new Random();
        newCurrentRound.timer = timer.Next(10, 55);
        activeMatch.rounds[indexRound] = newCurrentRound;
        tempRound = SubExecute(activeMatch);
        activeMatch.rounds[indexRound] = tempRound;
        _matchRepository.SaveMatch(activeMatch);
    }

    private Round SubExecute(Match match)
    {
        //Referenciar a una Clase MatchAction
        Round currentRound = match.rounds.First(r => r.roundFinished == false && r != null);
        CategoriesGetter categoriesGetter = new CategoriesGetter(new CategoryService());
        var categories = categoriesGetter.GetCategories(5);
        string[] currentCatergories = currentRound.assignedCategoryNames;
        string[] answers = new string[5];
        bool[] result = new bool[5];
        for (int i = 0; i < 5; i++)
        {
            var category = categories.First(c => c.Name == currentCatergories[i]);
            Random random = new Random();
            int index = random.Next(0, category.Words.Count);
            answers[i] = category.Words[index];
            result[i] = category.ExisistInCategory(answers[i], (char)currentRound.letter);
        }
        currentRound.opponentAnswers = answers;
        currentRound.opponentResult = result;
        return currentRound;
        
    }
}
*/
