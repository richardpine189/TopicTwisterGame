namespace Architecture.Bot
{
    public class User
    {
        private int id;
        private string name;

        public string UserName
        {
            get
            {
                return name;
            }
        }

        public User(int userId, string userName)
        {
            id = userId;
            name = userName;
        }
    }
}