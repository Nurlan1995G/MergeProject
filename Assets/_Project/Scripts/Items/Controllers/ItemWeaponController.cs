using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.Items.Factory;
using Assets._Project.Scripts.Items.Logic;
using Assets._Project.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Items.Controllers
{
    public class ItemWeaponController : MonoBehaviour
    {
        private ItemSpawner _itemSpawner;
        private ItemWeaponModel _itemWeaponModel;
        private ItemWeaponView _view;
        private CellView _currentPoint;

        public void Initialize(LevelData levelData)
        {
            ItemFactory factory = new ItemFactory();
            _itemSpawner = new ItemSpawner(factory);
        }

        public void PlaceOnCell(CellView cell)
        {
            _view.SetCurrentCell(cell);
            _view.transform.position = cell.transform.position;
            cell.MarkAsBusy();
        }

        public void RemoveFromCell()
        {
            if (_view.CurrentCell != null)
            {
                _view.CurrentCell.MarkAsFree();
                _view.SetCurrentCell(null);
            }
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

                Debug.Log($"Spawned Item - Level {model.Level}, Type {model.ItemType}, ID {model.ID}");
            }
        }

        public void SpawnItems(ItemWeaponData itemData, CellView targetCell)
        {
            int id = ItemIDGenerator.GetUniqueID();

            var model = new ItemWeaponModel(id, itemData.Level, itemData.Price, itemData.Reward, itemData.ItemType);

            var item = _itemSpawner.SpawnItem(itemData, targetCell.transform.position);

            item.CreateModel(model);
            targetCell.GetPlaceItem(item);

            Debug.Log($"Spawned Item - Level {model.Level}, Type {model.ItemType}, ID {model.ID}");
        }
    }
}