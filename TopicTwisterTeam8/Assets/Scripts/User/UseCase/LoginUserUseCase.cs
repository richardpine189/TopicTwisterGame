using System.Threading.Tasks;
using Newtonsoft.Json;

public class LoginUserUseCase : ILoginGetUserUseCase
{
    private IUserGateway _loginService;

    private ILocalPlayerDataRepository _localPlayerDataRepository;

    public LoginUserUseCase(IUserGateway loginService, ILocalPlayerDataRepository localPlayerDataRepository)
    {
        _loginService = loginService;
        _localPlayerDataRepository = localPlayerDataRepository;
    }

    public async Task Invoke(string userName)
    {
        var tempUser = await _loginService.RequestLogin(userName);
        UserDTO userDto = UserJsonToDTO(tempUser);

        _localPlayerDataRepository.SetData(userDto);
    }

    public UserDTO UserJsonToDTO(string userJson)
    {
        return JsonConvert.DeserializeObject<UserDTO>(userJson);
    }
}