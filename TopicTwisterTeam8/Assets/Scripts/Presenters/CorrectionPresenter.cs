using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


class CorrectionPresenter
{
    private bool[] _results;
    private ICorrectionView _view;
    private IGetCorrections _getCorrections;
    private IMatchAction _matchActions;

    public CorrectionPresenter(ICorrectionView view, IGetCorrections getCorrections)
    {
        _view = view;
        _getCorrections = getCorrections;
        _matchActions = new HardcodedMatchActions();
        //_view.OnNextTurnClick += EndTurn;
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
        round.challengerResult = _results;

        if (round.opponentAnswers != null)
        {
            round.roundFinished = true;
        }

        match.rounds[currentRoundIndex] = round;
        match.isChallengerTurn = !match.isChallengerTurn; //SE VA A ROMPEEEEER!!!!
        SaveMatch action = new SaveMatch();
        action.Save(match);

        if (round.roundFinished)
        {
            _view.LoadNextTurn();
        }
        else
        {
            _view.ChangeScene();
        }
    }

    public async Task<bool[]> GetCorrections(string[] roundCategories, string[] answers, char letter)
    {
        _results = await _getCorrections.GetCorrections(roundCategories, answers, letter);

        return _results;
    }
}

