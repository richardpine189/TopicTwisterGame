using System;
using Zenject;

public class AnswersPresenter
{
    private IAnsweringView _view;

    private ISaveRoundDataUseCase _saveRoundDataUseCase;

    public AnswersPresenter(IAnsweringView view, ISaveRoundDataUseCase saveRoundDataUseCase)
    {
        _view = view;
        _saveRoundDataUseCase = saveRoundDataUseCase;
        _view.OnStopClick += SendAnswersAction;
    }

    ~AnswersPresenter()
    {
        _view.OnStopClick -= SendAnswersAction;
    }

    private void SendAnswersAction(string[] answers)
    {
        _saveRoundDataUseCase.SaveCurrentAnswers(answers);
    }
}
