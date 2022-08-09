using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;


public class LoginAction : ILoginGetUserAction
{
    [Inject] private ILoginService _loginService;
    public async Task Invoke(string userName)
    {
        var tempUser = await _loginService.RequestLogin(userName);
        LoggedUserDTO userDto = UserJsonToDTO(tempUser);
        SaveToPlayerPref(userDto);
        LoggedUserDTO.PlayerName = userDto.name; // OJO ACA!!!
    }

    public LoggedUserDTO UserJsonToDTO(string userJson)
    {
        return JsonConvert.DeserializeObject<LoggedUserDTO>(userJson);
    }

    private void SaveToPlayerPref(LoggedUserDTO user) // ME SIENTO SUCIO
    {
        PlayerPrefs.SetString("PlayerName", user.name);
        PlayerPrefs.SetString("PlayerEmail", user.email);
        PlayerPrefs.SetInt("PlayerId", user.id);
        PlayerPrefs.SetInt("PlayerCoin", user.coin);
        PlayerPrefs.Save();
    }
}


