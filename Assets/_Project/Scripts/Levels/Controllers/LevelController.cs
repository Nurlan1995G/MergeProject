using Assets._Project.Scripts.BackendService;
using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Scripts.Levels.Controllers
{
    public class LevelController : MonoBehaviour, ILevelController
    {
        private List<ItemWeaponData> _itemWeaponDatas;
        private IItemWeaponController _itemsController;
        private List<CellView> _cells;
        private GamesBeckendHandler _beckendHandler;

        private int OneLevelItem = 1;
        private int CountItem = 2;

        public void Initialize(IItemWeaponController itemsController, List<CellView> cells, List<ItemWeaponData> itemWeaponDatas, GamesBeckendHandler beckendHandler)
        {
            _itemWeaponDatas = itemWeaponDatas;
            _itemsController = itemsController;
            _cells = cells;
            _beckendHandler = beckendHandler;
        }

        public void TryBuyItem()
        {
            if(_beckendHandler.GetCurrentBalance() <= 0)
                    return;

            var freeCells = GetFreeCells();

            if (freeCells.Count == 0)
            {
                Debug.Log("Нет свободных ячеек для покупки.");
                return;
            }

            var itemData = GetItemDataByLevel(1);

            if (itemData != null)
            {
                CellView targetCell = freeCells[0];
                ItemWeaponView item = _itemsController.SpawnItems(itemData, targetCell);
                _beckendHandler.PostSpend(item.ItemWeaponModel.Price);
            }
        }

        public void SpawnInitialItems(GamesBeckendHandler backend)
        {
            var freeCells = GetFreeCells();
            var itemData = GetItemDataByLevel(OneLevelItem);

            if (freeCells.Count < 2 || itemData == null) return;

            var selected = freeCells.Take(CountItem).ToList();

            foreach (var cell in selected)
            {
                ItemWeaponView item = _itemsController.SpawnItems(itemData, cell);
                backend.PostItems(item);
            }
        }

        public void RestoreItems(List<ItemWeaponSaveData> savedItems)
        {
            foreach (var saved in savedItems)
            {
                var cell = GetFreeCells().FirstOrDefault();
                if (cell == null) continue;

                var itemData = _itemWeaponDatas.FirstOrDefault(d => d.Level == saved.Level);
                if (itemData == null) continue;

                var item = _itemsController.SpawnItems(itemData, cell);
                item.CreateModel(new ItemWeaponModel(saved.Id, saved.Level, saved.Price, saved.Reward, Enum.Parse<ItemType>(saved.ItemType)));
            }
        }

        private List<CellView> GetFreeCells() => _cells.Where(c => !c.IsBusy).ToList();

        private ItemWeaponData GetItemDataByLevel(int level) =>
            _itemWeaponDatas.FirstOrDefault(d => d.Level == level);
    }
}
