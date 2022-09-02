using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersPresenter
{
    private IAnsweringView _view;

    // The presenter shouldn't communicate with the repository directly, only indirectly through the action layer.
    private IAnswersRepository _answersRepository;
    private IMatchAction _matchActions;
    private Match match;

    public AnswersPresenter(IAnsweringView view)
    {
        _view = view;
        _matchActions = new HardcodedRoundActions();
        match = _matchActions.Match;
        _view.OnStopClick += SendAnswersAction;
    }

    private void SendAnswersAction(string[] answers)
    {
        match.currentAnswers = answers;
        _matchActions.Match = match;
    }

    
}
