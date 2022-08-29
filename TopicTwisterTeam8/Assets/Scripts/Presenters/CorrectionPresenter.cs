using Assets.Scripts.Core.Match.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

class CorrectionPresenter
{
    private bool[] _results;
    private ICorrectionView _view;
    private IGetCorrections _getCorrections;
    private IMatchAction _inMemoryMatchActions;
    private IUpdateMatchUseCase _updateMatch;
    private MatchDTO match;

    public CorrectionPresenter(ICorrectionView view, IGetCorrections getCorrections, IUpdateMatchUseCase updateMatch)
    {
        _view = view;
        _view.EndTurn += EndTurn;
        _getCorrections = getCorrections;
        _updateMatch = updateMatch;
        _inMemoryMatchActions = new HardcodedRoundActions();
        match = _inMemoryMatchActions.Match;
        GetCorrections(match.currentCategories, match.currentAnswers, (char)match.currentLetter);
    }

    public async void EndTurn()
    {
        try
        {
            
            await _updateMatch.Execute(match);
            _view.ChangeScene();
            
            /*
            if (match.currentRound == 1)
            {
                _view.LoadNextTurn();
            }
            else
            {
                _view.ChangeScene();
            }
            */
        }
        catch(Exception ex)
        {
            _view.ShowErrorPanel(ex.Message);
        }
    }

    public async void GetCorrections(string[] roundCategories, string[] answers, char letter)
    {
        _results = await _getCorrections.GetCorrections(roundCategories, answers, letter);

        match.currentResults = _results;

        _view.ShowAnswers(answers);

        _view.ShowCategories(roundCategories);

        _view.ShowCorrections(_results);
    }
}

