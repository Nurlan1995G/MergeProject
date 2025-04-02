using System;
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

        public int GetLevel()
        {
            return _playerData.Level;
        }

        public void AddBalance(int amount)
        {
            _playerData.Balance += amount;
            Debug.Log($"Баланс обновлен: {_playerData.Balance}");
        }

        public void LevelUp()
        {
            _playerData.Level += 1;
            Debug.Log($"Уровень повышен: {_playerData.Level}");
        }
    }
}