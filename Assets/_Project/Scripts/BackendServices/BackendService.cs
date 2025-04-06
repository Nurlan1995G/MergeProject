using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.BackendService
{
    public class BackendService : MonoBehaviour
    {
        private PlayerData _playerData = new PlayerData();

        public PlayerData GetPlayerData() => _playerData;

        public event Action<int> OnBalanceChanged;
        public event Action OnInitialized;

        private void Awake()
        {
            //Initialize();
        }

        public void Initialize()
        {
            LoadPlayerData();
            OnInitialized?.Invoke();
        }

        public void LoadPlayerData()
        {
            if (PlayerPrefs.HasKey("PlayerData"))
            {
                string json = PlayerPrefs.GetString("PlayerData");
                _playerData = JsonUtility.FromJson<PlayerData>(json);
            }
            else
            {
                _playerData = new PlayerData();
            }

            Debug.Log("Balance - " + _playerData.Balance);

            OnBalanceChanged?.Invoke(_playerData.Balance);
        }

        public void AddReward(int amount)
        {
            _playerData.AddBalance(amount);
            SavePlayerData();
            OnBalanceChanged?.Invoke(_playerData.Balance);
        }

        public void RemoveSpend(int amount)
        {
            _playerData.RemoveBalance(amount);
            SavePlayerData();
            OnBalanceChanged?.Invoke(_playerData.Balance);
        }

        public void AddItemWeapon(ItemWeaponView item)
        {
            var model = item.ItemWeaponModel;

            ItemWeaponSaveData saveData = new ItemWeaponSaveData
            {
                Id = model.ID,
                Level = model.Level,
                Price = model.Price,
                Reward = model.Reward,
                ItemType = model.ItemType.ToString()
            };

            _playerData.AddItem(saveData);
            SavePlayerData();
        }

        public List<ItemWeaponSaveData> GetSavedItems()
        {
            return _playerData.SaveItems;
        }

        public void RemoveItemWeapon(ItemWeaponView item)
        {
            var model = item.ItemWeaponModel;

            ItemWeaponSaveData saveData = new ItemWeaponSaveData
            {
                Id = model.ID,
                Level = model.Level,
                Price = model.Price,
                Reward = model.Reward,
                ItemType = model.ItemType.ToString()
            };

            _playerData.RemoveItem(saveData);
            SavePlayerData();
        }

        public void SavePlayerData()
        {
            string json = JsonUtility.ToJson(_playerData);
            PlayerPrefs.SetString("PlayerData", json);
            PlayerPrefs.Save();
        }

        [Serializable]
        public struct ItemData
        {
            public string Name;
            public int ID;
            public ItemWeaponView ItemWeaponView;
        }

        [Serializable]
        public struct RewardData
        {
            public string Name;
            public int Amount;
        }
    }
}