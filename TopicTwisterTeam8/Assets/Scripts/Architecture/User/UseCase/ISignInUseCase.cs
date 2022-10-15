using System.Threading.Tasks;

namespace Architecture.User.UseCase
{
    public interface ISignInUseCase
    {
        Task Invoke(string userName, string email);
    }
}