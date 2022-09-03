using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AnswersPresenter
{
    private IAnsweringView _view;

    [Inject]
    private IActiveMatch _activeMatch;

    private Match match;

    public AnswersPresenter(IAnsweringView view)
    {
        _view = view;
        match = _activeMatch.Match;
        _view.OnStopClick += SendAnswersAction;
    }

    private void SendAnswersAction(string[] answers)
    {
        match.currentAnswers = answers;
        _activeMatch.Match = match;
    }

    
}
