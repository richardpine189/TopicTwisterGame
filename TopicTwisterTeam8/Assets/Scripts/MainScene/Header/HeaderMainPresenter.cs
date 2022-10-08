using PlasticPipe.PlasticProtocol.Messages;

namespace MainScene.Header
{
    public class HeaderMainPresenter
    {
        private readonly ILocalPlayerDataRepository _playerDataRepository;
        private readonly IHeaderMainView _headerMainView;

        public HeaderMainPresenter(IHeaderMainView headerMainView, ILocalPlayerDataRepository playerDataRepository)
        {
            _headerMainView = headerMainView;
            _playerDataRepository = playerDataRepository;

            SetPlayerData();
        }

        private void SetPlayerData()
        {
            UserDTO userData = _playerDataRepository.GetData();
            _headerMainView.SetUserDataInHeader(userData.name, userData.coin.ToString(), userData.victories.ToString());
        }
    }
}