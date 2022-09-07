using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

public class NewGamePresenter: IInitializable, IDisposable
{
    [Inject] private INewGameView _view;
    [Inject] private ISaveMatchId _saveMatchId;


    public void Initialize()
    {
        _view.OnNewGameButtonClick += LoadGameLoopScene;
    }

    public void Dispose()
    {
        _view.OnNewGameButtonClick -= LoadGameLoopScene;
    }

    private void LoadGameLoopScene()
    {
        _saveMatchId.Invoke(-1);
        SceneManager.LoadScene("GameScene");
    }

    
}
