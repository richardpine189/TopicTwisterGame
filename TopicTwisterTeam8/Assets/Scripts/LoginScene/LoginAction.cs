using System.Threading.Tasks;
using Newtonsoft.Json;
using Zenject;


public class LoginAction : ILoginGetUserAction
{
    [Inject] private ILoginService _loginService;
    public async Task Invoke(string userName)
    {
        var tempUser = await _loginService.RequestLogin(userName);
        LoggedUserDTO userDto = UserJsonToDTO(tempUser);
        LoggedUserDTO.PlayerName = userDto.name; // OJO ACA!!!
    }

    public LoggedUserDTO UserJsonToDTO(string userJson)
    {
        return JsonConvert.DeserializeObject<LoggedUserDTO>(userJson);
    }
}


