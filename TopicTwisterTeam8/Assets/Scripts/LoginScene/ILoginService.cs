using System.Threading.Tasks;

public interface ILoginService
{
    Task<string> RequestLogin(string username);
}
