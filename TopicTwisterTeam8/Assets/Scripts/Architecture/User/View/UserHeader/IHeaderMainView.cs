namespace Architecture.User.View.UserHeader
{
    public interface IHeaderMainView
    {
        void SetUserDataInHeader(string loggedUserName, string loggedUserCoin, string loggedUserVictories);
    }
}