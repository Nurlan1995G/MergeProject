using Assets._Project.Scripts.Items.Factory;
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

        public List<ItemWeaponView> SpawnItems(List<Vector3> cellPositions)
        {
            List<ItemWeaponView> spawnedItems = new List<ItemWeaponView>();

            foreach (var position in cellPositions)
            {
                ItemWeaponView item = _itemFactory.GetItem(position);
                spawnedItems.Add(item);
            }

            return spawnedItems;
        }
    }
}
