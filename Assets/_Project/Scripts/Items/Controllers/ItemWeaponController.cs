using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.Items.Factory;
using Assets._Project.Scripts.Items.Logic;
using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Items.Controllers
{
    public class ItemWeaponController : MonoBehaviour
    {
        private ItemSpawner _itemSpawner;

        public void Initialize(LevelData levelData)
        {
            ItemFactory factory = new ItemFactory();
            _itemSpawner = new ItemSpawner(factory);
        }

        public void SpawnItems(ItemWeaponData itemData, List<CellView> cells)
        {
            foreach (var cell in cells)
            {
                int id = ItemIDGenerator.GetUniqueID();

                var model = new ItemWeaponModel(id, itemData.Level, itemData.Price, itemData.Reward, itemData.ItemType);

                var item = _itemSpawner.SpawnItem(itemData, cell.transform.position);

                item.CreateModel(model);
                cell.GetPlaceItem(item);
            }
        }

        public void SpawnItems(ItemWeaponData itemData, CellView targetCell)
        {
            int id = ItemIDGenerator.GetUniqueID();

            var model = new ItemWeaponModel(id, itemData.Level, itemData.Price, itemData.Reward, itemData.ItemType);

            var item = _itemSpawner.SpawnItem(itemData, targetCell.transform.position);

            item.CreateModel(model);
            targetCell.GetPlaceItem(item);
        }
    }
}