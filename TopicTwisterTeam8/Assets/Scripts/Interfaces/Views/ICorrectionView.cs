using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICorrectionView
{
    //event Action<string[], string[], char> OnNextTurnClick;

    void ShowCorrections();
    void ChangeScene();
    void LoadNextTurn();
}

