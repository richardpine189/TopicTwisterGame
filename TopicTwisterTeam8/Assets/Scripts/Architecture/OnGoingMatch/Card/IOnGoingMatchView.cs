using System;
using System.Drawing;

public interface IOngoingMatchView
{
    public event Action OnStartMatch;

    public void ShowWaitingClock();

    public void ShowPlayButton();

    public void SetOpponentName(string name);

    public void SetRoundNumber(int round);

    void LoadMatch();

    void SetRoundCount(string formatingScore);

    void SetCardColor(Color color);
}
