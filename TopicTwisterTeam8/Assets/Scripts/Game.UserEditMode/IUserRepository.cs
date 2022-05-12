using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team8.TopicTwister.Assets.Scripts
{
    public interface IUserRepository
    {
        User GetUser(int userId);

        void CreateUser(string email);

        void UpdateUser(User user);
    }
}
