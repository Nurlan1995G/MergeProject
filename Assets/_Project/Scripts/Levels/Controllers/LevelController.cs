using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.Items.Controllers;
using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Scripts.Levels.Controllers
{
    public class LevelController : MonoBehaviour
    {
        private List<ItemWeaponData> _itemWeaponDatas;
        private ItemWeaponController _itemsController;
        private List<CellView> _cells;

        public void Initialize(ItemWeaponController itemsController, List<CellView> cells, List<ItemWeaponData> itemWeaponDatas)
        {
            _itemWeaponDatas = itemWeaponDatas;
            _itemsController = itemsController;
            _cells = cells;

            SpawnInitialItems();
        }

        private void SpawnInitialItems()
        {
            var freeCells = GetFreeCells();

            if (freeCells.Count < 2)
                return;

            var itemData = GetItemDataByLevel(1);
            if (itemData == null)
                return;

            var selectedCells = freeCells.OrderBy(_ => Random.value).Take(2).ToList();
            _itemsController.SpawnItems(itemData, selectedCells);
        }


        public void TryBuyItem()
        {
            var freeCells = GetFreeCells();
            
            if (freeCells.Count == 0)
            {
                Debug.Log("Нет свободных ячеек для покупки.");
                return;
            }

            var itemData = GetItemDataByLevel(1);

            if (itemData != null)
            {
                var targetCell = freeCells[0];
                _itemsController.SpawnItems(itemData, targetCell);
            }
        }

        private List<CellView> GetFreeCells() => 
            _cells.Where(cell => !cell.IsBusy).ToList();

        private ItemWeaponData GetItemDataByLevel(int level) => 
            _itemWeaponDatas.FirstOrDefault(data => data.Level == level);
    }
}
