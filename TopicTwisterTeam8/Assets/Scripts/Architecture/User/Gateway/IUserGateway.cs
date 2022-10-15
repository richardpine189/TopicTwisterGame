using System.Threading.Tasks;

public interface IUserGateway
{
    Task<string> RequestLogin(string username);

    Task<string> RequestSignIn(string username, string email);
}
