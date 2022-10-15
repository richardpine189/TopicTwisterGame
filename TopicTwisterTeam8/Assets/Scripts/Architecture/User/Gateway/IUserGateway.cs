using System.Threading.Tasks;

namespace Architecture.User.Gateway
{
    public interface IUserGateway
    {
        Task<string> RequestLogin(string username);

        Task<string> RequestSignIn(string username, string email);
    }
}
