using System;
using Zenject;

class CorrectionPresenter
{
    private bool[] _results;
    private ICorrectionView _view;
    private IGetCorrections _getCorrections;
    private IUpdateMatchUseCase _updateMatch;

    [Inject]
    private IGetRoundData _getRoundData;

    [Inject]
    private ISaveRoundData _saveRoundData;

    [Inject]
    private RemoveActiveMatch _remove;
    
    [Inject]
    private ResetActiveMatch _resetActiveMatch;

    public CorrectionPresenter(ICorrectionView view, IGetCorrections getCorrections, IUpdateMatchUseCase updateMatch)
    {
        _view = view;
        _getCorrections = getCorrections;
        _updateMatch = updateMatch;
        _view.OnEndTurn += EndTurn;
        _view.OnGetCorrections += GetCorrections;
    }

    ~CorrectionPresenter()
    {
        _view.OnEndTurn -= EndTurn;
        _view.OnGetCorrections -= GetCorrections;
    }

    public async void EndTurn()
    {
        try
        {
            bool showEndRoundPanel = await _updateMatch.Execute();

            if(showEndRoundPanel)
            {
                _resetActiveMatch.Execute();
                _view.LoadNextTurn();
            }
            else
            {
                _remove.Execute();
                _view.ChangeScene();
            }
        }
        catch(Exception ex)
        {
            _view.ShowErrorPanel(ex.Message);
        }
    }

    public async void GetCorrections()
    {
        var answers = _getRoundData.GetCurrentAnswers();

        _results = await _getCorrections.GetCorrections(_getRoundData.GetCurrentCategories(), answers, (char)_getRoundData.GetCurrentLetter());

        _saveRoundData.SaveCurrentResults(_results);

        _view.ShowAnswers(answers);

        _view.ShowCorrections(_results);
    }

}

