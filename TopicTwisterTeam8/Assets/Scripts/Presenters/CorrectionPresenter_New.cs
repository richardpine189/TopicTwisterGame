using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class CorrectionPresenter_New
{
    private bool[] results;
    private ICorrectionView_New _view;
    private IMatchAction _matchActions;
    private ICorrectionAction _correctionAction;

    public CorrectionPresenter_New(ICorrectionView_New view)
    {
        _view = view;
        _matchActions = new HardcodedMatchActions();
        _correctionAction = new JsonAPICorrectionAction();
        //_view.OnNextTurnClick += EndTurn;
        _view.OnStart += GetCorrections;
    }
    
    public void EndTurn(string[] roundCategories, string[] answers, char letter)
    {
        // This assaingment should be inside a method of the actions object
        Match match = _matchActions.GetMatch();
        int currentRoundIndex = _matchActions.GetCurrentRoundIndex();

        Round round = _matchActions.GetCurrentRound() != null ? _matchActions.GetCurrentRound() : new Round();

        round.assignedCategoryNames = roundCategories;
        round.letter = letter;
        round.challengerAnswers = answers;
        round.challengerResult = results;

        if(round.opponentAnswers != null)
        {
            round.roundFinished = true;
        }

        match.rounds[currentRoundIndex] = round;

        SaveMatch action = new SaveMatch();
        action.Save(match);

        if(round.roundFinished)
        {
            _view.LoadNextTurn();
        }
        else
        {
            _view.ChangeScene();
        }
    }
    
    public async void GetCorrections(string[] roundCategories, string[] answers, char letter)
    {
        results = new bool[5];

        for(int i = 0; i < 5; i++)
        {
            //results[i] = categories.FirstOrDefault(x => x.Name == roundCategories[i]).ExisistInCategory(answers[i], letter);
            results[i] = await _correctionAction.GetCorrection(answers[i], roundCategories[i]);
        }

        _view.ShowCorrections(results);
    }
}

internal class JsonAPICorrectionAction : ICorrectionAction
{
    // This should be in a general config file for the whole project
    private static readonly HttpClient client = new HttpClient();

    // Development URL
    private static readonly string baseURL = @"http://localhost:8080";

    public async Task<bool> GetCorrection(string word, string categoryName)
    {
        //var values = new Dictionary<string, string>
        //{
        //    { "word", word }
        //};

        //var content = new FormUrlEncodedContent(values);

        var response = await client.GetAsync(baseURL + "/correction?word=" + word + "&category=" + categoryName);

        var responseString = await response.Content.ReadAsStringAsync();

        return Convert.ToBoolean(responseString);
    }
}

internal interface ICorrectionAction
{
    Task<bool> GetCorrection(string word, string categoryName);
}