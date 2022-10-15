using System.Threading.Tasks;

namespace Architecture.Match.UseCases.UpdateMatch
{
    interface IUpdateMatchUseCase
    {
        Task<bool> Invoke();
    }
}
