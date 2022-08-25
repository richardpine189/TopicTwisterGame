using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersPresenter
{
    private IAnsweringView _view;

    // The presenter shouldn't communicate with the repository directly, only indirectly through the action layer.
    private IAnswersRepository _answersRepository;
    private IMatchAction _matchActions;

    public AnswersPresenter(IAnsweringView view, IAnswersRepository answersRepository)
    {
        _view = view;
        _answersRepository = answersRepository;
        _matchActions = new HardcodedRoundActions();
        _view.OnStopClick += SendAnswersAction;

        GetRoundNumber();
    }

    private void SendAnswersAction(string[] answers)
    {
        _answersRepository.SaveAnswers(answers);
    }

    private void GetRoundNumber()
    {
        _view.ShowRoundNumber(124);
    }
}
