using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICorrectionView_New
{
    event Action<string[], string[], char> OnStart;

    //event Action<string[], string[], char> OnNextTurnClick;

    void ShowCorrections(bool[] results);
    void ChangeScene();
    void LoadNextTurn();
}
