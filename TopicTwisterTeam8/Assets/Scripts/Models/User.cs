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

public class UserDTO
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public int coin { get; set; }
}