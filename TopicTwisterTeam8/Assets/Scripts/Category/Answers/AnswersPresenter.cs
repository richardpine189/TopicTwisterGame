using System;
using Zenject;

public class AnswersPresenter
{
    private IAnsweringView _view;

    private IAssignAnswersUseCase _assignAnswers;

    public AnswersPresenter(IAnsweringView view, IAssignAnswersUseCase assignAnswers)
    {
        _view = view;
        _assignAnswers = assignAnswers;
        _view.OnStopClick += SendAnswersAction;
    }

    ~AnswersPresenter()
    {
        _view.OnStopClick -= SendAnswersAction;
    }

    private void SendAnswersAction(string[] answers)
    {
        _assignAnswers.Execute(answers);
    }
}
