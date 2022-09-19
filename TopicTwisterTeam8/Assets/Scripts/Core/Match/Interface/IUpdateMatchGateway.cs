using System.Threading.Tasks;

namespace Core.Match.Interface
{
    public interface IUpdateMatchGateway
    {
        public Task<bool> UpdateMatch(Models.Match match);
    }
}