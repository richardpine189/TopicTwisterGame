using System;
using Zenject;

public class AnswersPresenter
{
    private IAnsweringView _view;

    private ISaveRoundData _saveRoundData;

    public AnswersPresenter(IAnsweringView view, ISaveRoundData saveRoundData)
    {
        _view = view;
        _saveRoundData = saveRoundData;
        _view.OnStopClick += SendAnswersAction;
    }

    ~AnswersPresenter()
    {
        _view.OnStopClick -= SendAnswersAction;
    }

    private void SendAnswersAction(string[] answers)
    {
        _saveRoundData.SaveCurrentAnswers(answers);
    }
}
