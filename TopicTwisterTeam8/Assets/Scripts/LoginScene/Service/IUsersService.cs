using System.Threading.Tasks;

public interface IUsersService
{
    Task<string> RequestLogin(string username);

    Task<string> RequestSignIn(string username, string email);
}
