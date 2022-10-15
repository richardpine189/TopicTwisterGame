using TMPro;
using UnityEngine;

namespace Core.Match.PlayersNames
{
    public class PlayerNameView : MonoBehaviour, IPlayerNameView
    {
        [SerializeField] private TextMeshProUGUI _challengerName;
        [SerializeField] private TextMeshProUGUI _opponentName;
        public void SetInUIPlayerName(string challenger, string opponent)
        {
            _challengerName.text = challenger;
            _opponentName.text = opponent;
        }
    }
}