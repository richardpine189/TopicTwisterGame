using System.Threading.Tasks;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using Zenject;

public class LoginAction : ILoginGetUserAction
{
    //[Inject]
    private ILoginService _loginService;

    private ILocalPlayerDataRepository _localPlayerDataRepository;

    public LoginAction(ILoginService loginService, ILocalPlayerDataRepository localPlayerDataRepository)
    {
        _loginService = loginService;
        _localPlayerDataRepository = localPlayerDataRepository;
    }

    public async Task Invoke(string userName)
    {
        var tempUser = await _loginService.RequestLogin(userName);
        UserDTO userDto = UserJsonToDTO(tempUser);

        _localPlayerDataRepository.SetData(userDto);

        UserDTO.PlayerName = userDto.name; // OJO ACA!!!
    }

    public UserDTO UserJsonToDTO(string userJson)
    {
        return JsonConvert.DeserializeObject<UserDTO>(userJson);
    }
}

public interface ILocalPlayerDataRepository
{
    void SetData(UserDTO userDto);

    UserDTO GetData();
}

public class PlayerPrefsPlayerDataRepository : ILocalPlayerDataRepository
{
    public UserDTO GetData()
    {
        UserDTO user = new UserDTO();
        user.name = PlayerPrefs.GetString("PlayerName");
        user.email = PlayerPrefs.GetString("PlayerEmail");
        user.id = PlayerPrefs.GetInt("PlayerId");
        user.coin = PlayerPrefs.GetInt("PlayerCoin");
        return user;
    }

    public void SetData(UserDTO userDto)
    {
        PlayerPrefs.SetString("PlayerName", userDto.name);
        PlayerPrefs.SetString("PlayerEmail", userDto.email);
        PlayerPrefs.SetInt("PlayerId", userDto.id);
        PlayerPrefs.SetInt("PlayerCoin", userDto.coin);
        PlayerPrefs.Save();
    }
}