using Architecture.User.Domain;
using UnityEngine;

namespace Architecture.User.Repository
{
    public class PlayerPrefsPlayerDataRepository : ILocalPlayerDataRepository
    {
        public UserDTO GetData()
        {
            UserDTO user = new UserDTO();
            user.name = PlayerPrefs.GetString("PlayerName");
            user.email = PlayerPrefs.GetString("PlayerEmail");
            user.id = PlayerPrefs.GetInt("PlayerId");
            user.coin = PlayerPrefs.GetInt("PlayerCoin");
            user.victories = PlayerPrefs.GetInt("PlayerVictories");
            return user;
        }

        public void SetData(UserDTO userDto)
        {
            PlayerPrefs.SetString("PlayerName", userDto.name);
            PlayerPrefs.SetString("PlayerEmail", userDto.email);
            PlayerPrefs.SetInt("PlayerId", userDto.id);
            PlayerPrefs.SetInt("PlayerCoin", userDto.coin);
            PlayerPrefs.SetInt("PlayerVictories", userDto.victories);
            PlayerPrefs.Save();
        }
    }
}
