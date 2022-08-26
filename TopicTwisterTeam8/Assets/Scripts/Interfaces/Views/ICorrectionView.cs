using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICorrectionView
{
    event Action EndTurn;

    void ShowCorrections(bool[] corrections);

    void ChangeScene();

    void LoadNextTurn();

    void ShowAnswers(string[] answers);

    void ShowCategories(string[] categories);

    void ShowErrorPanel(string message);
}

