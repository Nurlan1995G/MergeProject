using Assets._Project.Scripts.BackendService;
using TMPro;
using UnityEngine;

namespace Assets._Project.Scripts.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _balancePlayer;

        private GamesBeckendHandler _backendHandler;

        public void Construct(GamesBeckendHandler backendHandler)
        {
            _backendHandler = backendHandler;
            _backendHandler.OnBalanceChanged += UpdateBalance;  
        }

        public void UpdateBalance(int balance) => 
            _balancePlayer.text = $"{balance}";

        private void OnDisable()
        {
            if (_backendHandler != null)
                _backendHandler.OnBalanceChanged -= UpdateBalance;  
        }
    }
}
