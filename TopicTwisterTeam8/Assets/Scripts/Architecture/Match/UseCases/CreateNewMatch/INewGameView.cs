﻿using System;

namespace Architecture.Match.UseCases.CreateNewMatch
{
    public interface INewGameView
    {
        public void StartGame();
        event Action OnNewGameButtonClick;
    }
}

