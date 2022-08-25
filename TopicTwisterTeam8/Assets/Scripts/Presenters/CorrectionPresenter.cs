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
        _matchActions = new HardcodedRoundActions();
        //_view.OnNextTurnClick += EndTurn;
    }

    public void EndTurn(string[] roundCategories, string[] answers, char letter)
    {
        //LlamarServicio y Update
        /*
        if (round.roundFinished)
        {
            _view.LoadNextTurn();
        }
        else
        {
            _view.ChangeScene();
        }
        */
    }

    public async Task<bool[]> GetCorrections(string[] roundCategories, string[] answers, char letter)
    {
        _results = await _getCorrections.GetCorrections(roundCategories, answers, letter);

        return _results;
    }
}

