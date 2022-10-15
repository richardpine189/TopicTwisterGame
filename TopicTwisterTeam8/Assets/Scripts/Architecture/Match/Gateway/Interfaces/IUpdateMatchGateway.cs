using System.Threading.Tasks;

namespace Architecture.Match.Gateway.Interfaces
{
    public interface IUpdateMatchGateway
    {
        public Task<bool> UpdateMatch(Domain.Match match);
    }
}