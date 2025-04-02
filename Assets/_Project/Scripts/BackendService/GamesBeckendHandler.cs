using System;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public class GamesBeckendHandler : MonoBehaviour
    {
        [SerializeField] private BackendService _backendService;

        public void GetBalance(Action<string> onBalanceReceived)
        {
            string balance = _backendService.GetBalance();
            onBalanceReceived?.Invoke(balance);
        }

        public void GetLevel(Action<int> onLevelReceived)
        {
            int level = _backendService.GetLevel();
            onLevelReceived?.Invoke(level);
        }

        public void PostReward(int amount)
        {
            BackendService.RewardData rewardData = new BackendService.RewardData
            {
                Name = "balanceName",
                Amount = amount,
            };

            _backendService.AddBalance(rewardData.Amount);
        }

        public void PostLvlUp(int level)
        {
            BackendService.LvlUpData lvlUpData = new BackendService.LvlUpData
            {
                Name = "level",
                Level = level,
            };

            Debug.Log(lvlUpData.Level + " - LevelData.level");
        }
    }
}