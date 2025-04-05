using Assets._Project.Scripts.Input;
using Assets._Project.Scripts.Items.Controllers;
using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Scripts.Levels.Controllers
{
    public class MergeController : MonoBehaviour
    {
        private ItemWeaponController _itemController;
        private List<ItemWeaponData> _itemDatas;
        private PlayerInputHandler _inputHandler;

        public void Initialize(ItemWeaponController itemController, List<ItemWeaponData> itemDatas, PlayerInputHandler inputHandler)
        {
            _itemController = itemController;
            _itemDatas = itemDatas;
            _inputHandler = inputHandler;
            
            _inputHandler.OnMergeRequested += TryMerge;
        }

        public void TryMerge(ItemWeaponView sourceItem, ItemWeaponView targetItem)
        {
            if (sourceItem == null || targetItem == null || sourceItem == targetItem) return;

            if (!CanMerge(sourceItem, targetItem))
                return;

            var sourceData = sourceItem.ItemWeaponModel;
            var targetData = targetItem.ItemWeaponModel;

            var nextLevel = sourceData.Level + 1;
            var nextData = _itemDatas.FirstOrDefault(d => d.Level == nextLevel);

            if (nextData == null)
            {
                Debug.Log("Макс. уровень");
                return;
            }

            var mergeCell = targetItem.CurrentCell;

            sourceItem.CurrentCell.MarkAsFree();
            targetItem.CurrentCell.MarkAsFree();

            Destroy(sourceItem.gameObject);
            Destroy(targetItem.gameObject);

            _itemController.SpawnItems(nextData, mergeCell);
        }

        private void OnDisable() => 
            _inputHandler.OnMergeRequested -= TryMerge;

        private bool CanMerge(ItemWeaponView sourceItem, ItemWeaponView targetItem)
        {
            return sourceItem.ItemWeaponModel.ItemType == targetItem.ItemWeaponModel.ItemType &&
                   sourceItem.ItemWeaponModel.Level == targetItem.ItemWeaponModel.Level &&
                   sourceItem.ItemWeaponModel.ID != targetItem.ItemWeaponModel.ID;
        }
    }
}
