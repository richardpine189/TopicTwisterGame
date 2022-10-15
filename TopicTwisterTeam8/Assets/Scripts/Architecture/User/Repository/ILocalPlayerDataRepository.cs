
using Architecture.User.Domain;

namespace Architecture.User.Repository
{
    public interface ILocalPlayerDataRepository
    {
        void SetData(UserDTO userDto);

        UserDTO GetData();
    }
}
