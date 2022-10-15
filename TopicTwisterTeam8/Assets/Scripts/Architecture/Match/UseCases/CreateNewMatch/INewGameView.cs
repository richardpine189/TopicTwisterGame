using System;

namespace Architecture.Match.UseCases.CreateNewMatch
{
    public interface INewGameView
    {
        public void LoadGameScene();
        event Action OnNewGameButtonClick;
    }
}

