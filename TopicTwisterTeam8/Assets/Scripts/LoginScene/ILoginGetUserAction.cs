using System.Threading.Tasks;

public interface ILoginGetUserAction
{
    Task Invoke(string userName);
    UserDTO UserJsonToDTO(string userJson);
}