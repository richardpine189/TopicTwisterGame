using System;

public interface IOngoingMatchView
{
    public void ShowWaitingClock();

    public void ShowPlayButton();

    public void SetOpponentName(string name);

    public void SetRoundNumber(int round);

    void LoadMatch();

    public event Action OnStartMatch;
    void SetRoundCount(string formatingScore);
}
