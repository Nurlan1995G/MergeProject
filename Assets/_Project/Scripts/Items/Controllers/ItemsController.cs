using Assets._Project.Scripts.Items.Factory;
using Assets._Project.Scripts.Items.Logic;
using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Items.Controllers
{
    public class ItemsController : MonoBehaviour
    {
        private ItemSpawner _itemSpawner;

        public void Initialize(LevelData levelData)
        {
            ItemFactory factory = new ItemFactory(levelData);
            _itemSpawner = new ItemSpawner(factory);
        }

        public void SpawnItem(List<Vector3> cellPositions)
        {
            List<ItemWeaponView> spawnedItems = _itemSpawner.SpawnItems(cellPositions);

            foreach (var itemWeapon in spawnedItems)
            {
                int uniqueID = ItemIDGenerator.GetUniqueID();
                itemWeapon.SetItemWeaponModel(uniqueID);
                Debug.Log("NameItem - " + itemWeapon.name + " = ID - " + uniqueID);
            }
        }
    }
}