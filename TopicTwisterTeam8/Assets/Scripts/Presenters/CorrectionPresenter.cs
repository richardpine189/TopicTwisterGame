using Assets.Scripts.Core.Match.Interface;
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

    public void EndTurn()
    {
        //LlamarServicio y Update
        _updateMatch.Execute(match);

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

    public async void GetCorrections(string[] roundCategories, string[] answers, char letter)
    {
        _results = await _getCorrections.GetCorrections(roundCategories, answers, letter);

        match.currentResults = _results;

        _view.ShowAnswers(answers);

        _view.ShowCategories(roundCategories);

        _view.ShowCorrections(_results);
    }
}

