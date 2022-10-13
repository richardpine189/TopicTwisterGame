using System.Threading.Tasks;

public interface ISignInUseCase
{
    Task Invoke(string userName, string email);
}