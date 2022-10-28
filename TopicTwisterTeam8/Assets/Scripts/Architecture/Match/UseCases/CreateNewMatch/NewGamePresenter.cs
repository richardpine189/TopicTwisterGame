using Architecture.OnGoingMatch.UseCase;

namespace Architecture.Match.UseCases.CreateNewMatch
{
    public class NewGamePresenter
    {
        private INewGameView _view;
        private ISaveMatchId _saveMatchId;
        
        private const int ITS_NEW_MATCH = -1;
        public NewGamePresenter(INewGameView view, ISaveMatchId saveMatchId)
        {
            _view = view;
            _saveMatchId = saveMatchId;
            _view.OnNewGameButtonClick += LoadGameLoopScene;
        }

        ~NewGamePresenter()
        {
            _view.OnNewGameButtonClick -= LoadGameLoopScene;
        }

        private void LoadGameLoopScene()
        {
            _saveMatchId.Invoke(ITS_NEW_MATCH);
            _view.StartGame();
        }
    }
}
