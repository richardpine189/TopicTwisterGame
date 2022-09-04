using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Zenject;

class CorrectionPresenter : IInitializable
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

    public CorrectionPresenter(ICorrectionView view, IGetCorrections getCorrections, IUpdateMatchUseCase updateMatch)
    {
        _view = view;
        _getCorrections = getCorrections;
        _updateMatch = updateMatch;
        _view.OnEndTurn += EndTurn;
        _view.OnGetCorrections += GetCorrections;
    }

    public void Initialize() { }

    public async void EndTurn()
    {
        try
        {
            bool continuePlaying = await _updateMatch.Execute();

            if(continuePlaying)
            {
                _view.LoadNextTurn();
            }
            else
            {
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

        _results = await _getCorrections.GetCorrections(_getCategories.Execute(), answers, _getLetter.Execute());

        _assignResults.Execute(_results);

        _view.ShowAnswers(answers);

        _view.ShowCorrections(_results);
    }

}

