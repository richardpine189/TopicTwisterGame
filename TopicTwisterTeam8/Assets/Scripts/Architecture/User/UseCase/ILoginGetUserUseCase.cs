using System.Threading.Tasks;
using Architecture.User.Domain;

namespace Architecture.User.UseCase
{
    public interface ILoginGetUserUseCase
    {
        Task Invoke(string userName);
        UserDTO UserJsonToDTO(string userJson);
    }
}