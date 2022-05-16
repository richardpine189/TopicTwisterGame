namespace Team8.TopicTwister.Assets.Scripts
{
    public class User
    {
        private int _userId;
        private string _userName;

        public string UserName
        {
            get
            {
                return _userName;
            }
        }

        public User(int userId, string userName)
        {
            _userId = userId;
            _userName = userName;
        }
    }
}