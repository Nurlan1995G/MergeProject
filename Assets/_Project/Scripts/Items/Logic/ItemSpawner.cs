using Assets._Project.Scripts.Items.Factory;
using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Items.Logic
{
    public class ItemSpawner
    {
        private readonly ItemFactory _itemFactory;

        public ItemSpawner(ItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public ItemWeaponView SpawnItem(ItemWeaponData weaponData, Vector3 cellPositions)
        {
            ItemWeaponView item = _itemFactory.GetItem(cellPositions, weaponData.PrefabItemWeapon);
            return item;
        }
    }
}
