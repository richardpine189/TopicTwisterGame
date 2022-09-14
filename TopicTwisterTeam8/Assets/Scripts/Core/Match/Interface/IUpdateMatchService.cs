using System.Threading.Tasks;

namespace Core.Match.Interface
{
    public interface IUpdateMatchService
    {
        public Task<bool> UpdateMatch(Models.Match match);
    }
}