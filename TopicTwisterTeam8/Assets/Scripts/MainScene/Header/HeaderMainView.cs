using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

public class HeaderMainView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _userName;

    [SerializeField]
    private TextMeshProUGUI _userCoins;

    [SerializeField]
    private Image _userAvatar;

    [Inject]
    private ILocalPlayerDataRepository _localPlayerDataRepository;

    void Start()
    {
        _userName.text = _localPlayerDataRepository.GetData().name;
        _userCoins.text = _localPlayerDataRepository.GetData().coin.ToString();
    }

}
