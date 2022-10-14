using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICorrectionView
{
    event Action OnEndTurn;

    event Action OnGetCorrections;

    void ShowCorrections(bool[] corrections);

    void ChangeScene();

    void LoadNextTurn();

    void ShowAnswers(string[] answers);

    void ShowErrorPanel(string message);
}

