
public class GetUserData : IGetUserDataUseCase
{
    private readonly ILocalPlayerDataRepository _playerRepository;

    public GetUserData(ILocalPlayerDataRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    public string GetUserName()
    {
        return _playerRepository.GetData().name;
    }

    public int GetUserCoin()
    {
        return _playerRepository.GetData().coin;
    }

    public int GetUserVictories()
    {
        return _playerRepository.GetData().victories;
    }
}
