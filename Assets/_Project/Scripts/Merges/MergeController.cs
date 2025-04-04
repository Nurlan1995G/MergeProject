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

        public void Initialize(ItemWeaponController itemController, List<ItemWeaponData> itemDatas)
        {
            _itemController = itemController;
            _itemDatas = itemDatas;
        }

        public void TryMerge(ItemWeaponView targetItem, ItemWeaponView sourceItem)
        {
            if (targetItem == null || sourceItem == null)
                return;

            if (targetItem == sourceItem)
                return;

            var targetData = targetItem.ItemWeaponModel;
            var sourceData = sourceItem.ItemWeaponModel;

            if (targetData.Level == sourceData.Level && targetData.ItemType == sourceData.ItemType)
            {
                var nextLevel = targetData.Level + 1;
                var nextItemData = _itemDatas.FirstOrDefault(d => d.Level == nextLevel && d.ItemType == targetData.ItemType);

                if (nextItemData == null)
                {
                    Debug.Log("Max level reached. No further merge.");
                    return;
                }

                var mergePosition = targetItem.transform.position;
                var mergeCell = targetItem.CurrentCell;

                mergeCell.MarkAsFree();
                Destroy(targetItem.gameObject);
                Destroy(sourceItem.gameObject);

                _itemController.SpawnItems(nextItemData, mergeCell);
            }
        }
    }
}
