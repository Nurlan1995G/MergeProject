using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Scripts.Items.Factory
{
    public class ItemFactory
    {
        public ItemWeaponView GetItem(Vector3 position, ItemWeaponView itemPrefabs)
        {
            ItemWeaponView item = Object.Instantiate(itemPrefabs, position, Quaternion.identity);
            return item;
        }
    }
}