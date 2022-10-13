using System.Threading.Tasks;

public class SignInUseCase : ISignInUseCase
{
    private IUsersService _usersService;

    public SignInUseCase(IUsersService loginService)
    {
        _usersService = loginService;
    }

    public async Task Invoke(string userName, string email)
    {
        var tempUser = await _usersService.RequestSignIn(userName, email);

        // Loguear automaticamente cuando se registra?
    }
}