using System.Threading.Tasks;

public interface ILoginGetUserAction
{
    Task Invoke(string userName);
    LoggedUserDTO UserJsonToDTO(string userJson);
}