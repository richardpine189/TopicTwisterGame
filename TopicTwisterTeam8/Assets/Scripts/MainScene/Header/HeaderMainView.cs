using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HeaderMainView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _userName;

    [SerializeField]
    private TextMeshProUGUI _userCoins;

    [SerializeField]
    private Image _userAvatar;

    void Start()
    {
        _userName.text = LoggedUserDTO.PlayerName;
    }

}
