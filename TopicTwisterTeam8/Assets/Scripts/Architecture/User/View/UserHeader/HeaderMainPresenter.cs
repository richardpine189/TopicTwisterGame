
namespace MainScene.Header
{
    public class HeaderMainPresenter
    {
        private readonly IGetUserDataUseCase _playerData;
        private readonly IHeaderMainView _headerMainView;

        public HeaderMainPresenter(IHeaderMainView headerMainView, IGetUserDataUseCase playerData)
        {
            _headerMainView = headerMainView;
            _playerData = playerData;

            SetPlayerData();
        }

        private void SetPlayerData()
        {
            string name = _playerData.GetUserName();
            int coin = _playerData.GetUserCoin();
            int victories = _playerData.GetUserVictories();
            _headerMainView.SetUserDataInHeader(name, coin.ToString(), victories.ToString());
        }
    }
}