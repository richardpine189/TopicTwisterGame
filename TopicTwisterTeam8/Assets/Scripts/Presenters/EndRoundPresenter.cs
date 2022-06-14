namespace Team8.TopicTwister
{
    public class EndRoundPresenter
    {
        private IEndRoundView _endRoundView;
        private IEndRoundAction _endRoundAction;
        public EndRoundPresenter(IEndRoundView endRoundView)
        {
            _endRoundView = endRoundView;
            _endRoundAction = new EndRoundAction();
        }
    }
}
