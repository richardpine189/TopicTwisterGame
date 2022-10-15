using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.User.View.UserHeader
{
    public class HeaderMainView : MonoBehaviour, IHeaderMainView
    {
        [SerializeField]
        private TextMeshProUGUI _userName;

        [SerializeField]
        private TextMeshProUGUI _userCoins;
    
        [SerializeField]
        private TextMeshProUGUI _victories;

        [SerializeField]
        private Image _userAvatar;




        public void SetUserDataInHeader(string loggedUserName, string loggedUserCoin, string loggedUserVictories)
        {
            _userName.text = loggedUserName;
            _userCoins.text = loggedUserCoin;
            _victories.text = loggedUserVictories;
        }
    }
}


