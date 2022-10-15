using System;

namespace Architecture.Category.CorrectionPanel
{
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
}

