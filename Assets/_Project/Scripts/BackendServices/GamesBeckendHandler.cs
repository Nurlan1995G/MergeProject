using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.BackendService
{
    public class GamesBeckendHandler : MonoBehaviour
    {
        [SerializeField] private BackendService _backendService;

        public event Action<int> OnBalanceChanged;

        public void Initialize(Action onBackendInitialized)
        {
            _backendService.OnInitialized += onBackendInitialized;
            _backendService.Initialize();
        }

        public void GetBalance(Action<int> callback) =>
            callback?.Invoke(_backendService.GetPlayerData().Balance);

        public void GetItems(Action<List<ItemWeaponSaveData>> callback) => 
            callback?.Invoke(_backendService.GetSavedItems());

        public int GetCurrentBalance() => 
            _backendService.GetPlayerData().Balance;

        public void PostReward(int amount)
        {
            BackendService.RewardData rewardData = new BackendService.RewardData
            {
                Name = "balanceName",
                Amount = amount,
            };

            _backendService.AddReward(rewardData.Amount);
            BalanceChanged();
        }

        public void PostSpend(int amount)
        {
            BackendService.RewardData rewardData = new BackendService.RewardData
            {
                Name = "balanceName",
                Amount = amount,
            };

            _backendService.RemoveSpend(rewardData.Amount);
            BalanceChanged();
        }

        public void PostItems(ItemWeaponView item)
        {
            BackendService.ItemData itemData = new BackendService.ItemData
            {
                Name = "item",
                ID = item.ItemWeaponModel.ID,
                ItemWeaponView = item,
            };

            _backendService.AddItemWeapon(itemData.ItemWeaponView);
        }

        public void PostSpendItems(ItemWeaponView item)
        {
            BackendService.ItemData itemData = new BackendService.ItemData
            {
                Name = "item",
                ID = item.ItemWeaponModel.ID,
                ItemWeaponView = item,
            };

            _backendService.RemoveItemWeapon(itemData.ItemWeaponView);
        }

        private void BalanceChanged()
        {
            int currentBalance = _backendService.GetPlayerData().Balance;
            OnBalanceChanged?.Invoke(currentBalance);
        }
    }
}