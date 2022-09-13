using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Zenject;

class CorrectionPresenter
{
    private bool[] _results;
    private ICorrectionView _view;
    private IGetCorrections _getCorrections;
    private IUpdateMatchUseCase _updateMatch;

    [Inject]
    private IGetMatchCategoriesUseCase _getCategories;

    [Inject]
    private IGetMatchLetterUseCase _getLetter;

    [Inject]
    private IGetMatchAnswersUseCase _getAnswers;

    [Inject]
    private IAssignResultsUseCase _assignResults;

    [Inject] private RemoveActiveMatch _remove;
    [Inject] private ResetActiveMatch _resetActiveMatch;

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
            bool continuePlaying = await _updateMatch.Execute();

            if(continuePlaying)
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
        var answers = _getAnswers.Execute();

        _results = await _getCorrections.GetCorrections(_getCategories.Execute(), answers, (char)_getLetter.Execute());

        _assignResults.Execute(_results);

        _view.ShowAnswers(answers);

        _view.ShowCorrections(_results);
    }

}

