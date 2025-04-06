using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts
{
    [Serializable]
    public class ItemWeaponSaveData
    {
        public int Id;
        public int Level;
        public int Price;
        public int Reward;
        public string ItemType;

        public override bool Equals(object obj)
        {
            if (obj is not ItemWeaponSaveData other)
                return false;

            return Id == other.Id &&
                   Level == other.Level &&
                   Price == other.Price &&
                   Reward == other.Reward &&
                   ItemType == other.ItemType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Level, Price, Reward, ItemType);
        }
    }

    [Serializable]
    public class PlayerData
    {
        [SerializeField] private List<ItemWeaponSaveData> _savedItems = new List<ItemWeaponSaveData>();

        [SerializeField] private int _balance;

        public int Balance => _balance;
        public List<ItemWeaponSaveData> SaveItems => _savedItems;

        public void AddBalance(int amount) => 
            _balance += amount;

        public void RemoveBalance(int amount) => 
            _balance -= amount;

        public void AddItem(ItemWeaponSaveData item)
        {
            if (!_savedItems.Contains(item))
                _savedItems.Add(item);
        }

        public void RemoveItem(ItemWeaponSaveData item) => 
            _savedItems.Remove(item);

        public void ClearItem() =>
            _savedItems.Clear();
    }
}