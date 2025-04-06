using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.Items.Factory;
using Assets._Project.Scripts.Items.Logic;
using Assets._Project.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets._Project.Scripts.Items.Controllers
{
    public class ItemWeaponController : IItemWeaponController
    {
        private ItemSpawner _itemSpawner;

        public ItemWeaponController()
        {
            ItemFactory factory = new ItemFactory();
            _itemSpawner = new ItemSpawner(factory);
        }

        public ItemWeaponView SpawnItems(ItemWeaponData itemData, CellView targetCell)
        {
            int id = ItemIDGenerator.GetUniqueID();

            var model = new ItemWeaponModel(id, itemData.Level, itemData.Price, itemData.Reward, itemData.ItemType);

            var item = _itemSpawner.SpawnItem(itemData, targetCell.transform.position);

            item.CreateModel(model);
            targetCell.GetPlaceItem(item);

            return item;
        }
    }
}