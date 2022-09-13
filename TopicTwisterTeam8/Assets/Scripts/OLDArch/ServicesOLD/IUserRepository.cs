using Models;
public interface IUserRepository
    {
        User GetUser(int userId);

        void CreateUser(string email);

        void UpdateUser(User user);
    }

