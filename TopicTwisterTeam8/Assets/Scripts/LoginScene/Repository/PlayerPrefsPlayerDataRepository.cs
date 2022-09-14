using UnityEngine;

public class PlayerPrefsPlayerDataRepository : ILocalPlayerDataRepository
{
    public UserDTO GetData()
    {
        UserDTO user = new UserDTO();
        user.name = PlayerPrefs.GetString("PlayerName");
        user.email = PlayerPrefs.GetString("PlayerEmail");
        user.id = PlayerPrefs.GetInt("PlayerId");
        user.coin = PlayerPrefs.GetInt("PlayerCoin");
        return user;
    }

    public void SetData(UserDTO userDto)
    {
        PlayerPrefs.SetString("PlayerName", userDto.name);
        PlayerPrefs.SetString("PlayerEmail", userDto.email);
        PlayerPrefs.SetInt("PlayerId", userDto.id);
        PlayerPrefs.SetInt("PlayerCoin", userDto.coin);
        PlayerPrefs.Save();
    }
}