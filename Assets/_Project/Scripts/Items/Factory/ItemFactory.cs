using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Scripts.Items.Factory
{
    public class ItemFactory
    {
        private readonly ItemWeaponView _itemPrefabs;

        public ItemFactory(LevelData levelData)
        {
            _itemPrefabs = levelData.ItemsHunterKnif;
        }

        public ItemWeaponView GetItem(Vector3 position)
        {
            ItemWeaponView item = Object.Instantiate(_itemPrefabs, position, Quaternion.identity);
            return item;
        }
    }
}