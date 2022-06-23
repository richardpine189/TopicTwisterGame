
    public class EndRoundPresenter
    {
        private IEndRoundView _view;
        private IEndRoundAction _action;
        public EndRoundPresenter(IEndRoundView endRoundView)
        {
            _view = endRoundView;
            _action = new EndRoundAction();

            _view.ShowCategories(_action.GetCategories());
            _view.ShowChallengerAnswersAndResult(_action.GetChallengerAnswers(), _action.GetChallengerResults());
            _view.ShowOponentAnswersAndResult(_action.GetOponentAnswers(), _action.GetOponentResults());
        }
    }

