using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public class BackendService : MonoBehaviour
    {
        private PlayerData _playerData = new PlayerData();

        [Serializable]
        public struct LvlUpData
        {
            public string Name;
            public int Id;
            public int Level;
            public int Max_level;
        }

        [Serializable]
        public struct RewardData
        {
            public string Name;
            public int Amount;
        }

        public string GetBalance()
        {
            return _playerData.Balance.ToString();
        }

        public List<ItemWeaponView> GetItemWeapon()
        {
            return _playerData.ItemWeaponViews;
        }

        public void AddBalance(int amount)
        {
            _playerData.Balance += amount;
            Debug.Log($"Баланс обновлен: {_playerData.Balance}");
        }

        public void AddItemWeapon(ItemWeaponView item)
        {
            _playerData.ItemWeaponViews.Add(item);
        }

        public void RemoveItemWeapon(ItemWeaponView item)
        {
            _playerData.ItemWeaponViews.Remove(item);
        }
    }
}