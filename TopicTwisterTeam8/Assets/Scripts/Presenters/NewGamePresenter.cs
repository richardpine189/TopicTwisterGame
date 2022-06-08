using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Presenters
{
    public class NewGamePresenter
    {
        private INewGameView _view;

        public NewGamePresenter(INewGameView view)
        {
            _view = view;
            _view.OnNewGameButtonClick += LoadGameLoopScene;
        }

        private void LoadGameLoopScene()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
