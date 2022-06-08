namespace TopicTwister.Assets.Scripts.Models
{
    public class Match
    {
        User _user;
        User _opponent;

        public User Player
        {
            get
            {
                return _user;
            }
        }

        public User Opponent
        {
            get
            {
                return _opponent;
            }
        }

        public Match(User user, User opponent)
        {
            _user = user;
            _opponent = opponent;
        }
    }
}