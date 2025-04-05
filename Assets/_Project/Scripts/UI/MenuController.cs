using TMPro;
using UnityEngine;

namespace Assets._Project.Scripts.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _balancePlayer;

        private PlayerData _playerData;

        public void Construct(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public void ShowBalancePlayer()
        {
            int balance = _playerData.Balance;
            _balancePlayer.text = $"{balance}";
        }
    }
}
