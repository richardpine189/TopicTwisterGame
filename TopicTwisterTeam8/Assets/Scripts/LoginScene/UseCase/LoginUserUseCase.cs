using System.Threading.Tasks;
using Unity.Plastic.Newtonsoft.Json;
public class LoginUserUseCase : ILoginGetUserUseCase
{
    private ILoginService _loginService;

    private ILocalPlayerDataRepository _localPlayerDataRepository;

    public LoginUserUseCase(ILoginService loginService, ILocalPlayerDataRepository localPlayerDataRepository)
    {
        _loginService = loginService;
        _localPlayerDataRepository = localPlayerDataRepository;
    }

    public async Task Invoke(string userName)
    {
        var tempUser = await _loginService.RequestLogin(userName);
        UserDTO userDto = UserJsonToDTO(tempUser);

        _localPlayerDataRepository.SetData(userDto);

        UserDTO.PlayerName = userDto.name; // OJO ACA con el estatico
    }

    public UserDTO UserJsonToDTO(string userJson)
    {
        return JsonConvert.DeserializeObject<UserDTO>(userJson);
    }
}