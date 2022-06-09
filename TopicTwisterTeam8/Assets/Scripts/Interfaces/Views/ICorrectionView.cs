using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICorrectionView
{
    event Action OnNextTurnClick;

    void ShowCorrections();
}
