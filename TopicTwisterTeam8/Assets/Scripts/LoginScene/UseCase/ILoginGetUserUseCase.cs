using System.Threading.Tasks;

public interface ILoginGetUserUseCase
{
    Task Invoke(string userName);
    UserDTO UserJsonToDTO(string userJson);
}