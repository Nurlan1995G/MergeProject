using Assets._Project.Scripts.BackendService;
using Assets._Project.Scripts.Input;
using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Scripts.Levels.Controllers
{
    public class MergeController : MonoBehaviour
    {
        private IItemWeaponController _itemController;
        private List<ItemWeaponData> _itemDatas;
        private PlayerInputHandler _inputHandler;
        private GamesBeckendHandler _beckendHandler;
        private MergeAnimator _mergeAnimator;

        public void Initialize(IItemWeaponController itemController, List<ItemWeaponData> itemDatas, PlayerInputHandler inputHandler, GamesBeckendHandler beckendHandler, MergeAnimator mergeAnimator)
        {
            _itemController = itemController;
            _itemDatas = itemDatas;
            _inputHandler = inputHandler;
            _beckendHandler = beckendHandler;
            _mergeAnimator = mergeAnimator;

            _inputHandler.OnMergeRequested += TryMerge;
        }

        private void OnDisable() =>
            _inputHandler.OnMergeRequested -= TryMerge;

        public void TryMerge(ItemWeaponView sourceItem, ItemWeaponView targetItem)
        {
            if (!IsValidMerge(sourceItem, targetItem)) return;

            var nextData = GetNextItemData(sourceItem.ItemWeaponModel.Level);

            if (nextData == null)
            {
                Debug.Log("Макс. уровень");
                return;
            }

            ExecuteMerge(sourceItem, targetItem, nextData);
        }

        private bool IsValidMerge(ItemWeaponView source, ItemWeaponView target)
        {
            return source != null &&
                   target != null &&
                   source != target &&
                   source.ItemWeaponModel.ItemType == target.ItemWeaponModel.ItemType &&
                   source.ItemWeaponModel.Level == target.ItemWeaponModel.Level &&
                   source.ItemWeaponModel.ID != target.ItemWeaponModel.ID;
        }

        private ItemWeaponData GetNextItemData(int currentLevel) => 
            _itemDatas.FirstOrDefault(d => d.Level == currentLevel + 1);

        private void ExecuteMerge(ItemWeaponView source, ItemWeaponView target, ItemWeaponData nextData)
        {
            var mergeCell = target.CurrentCell;

            FreeCells(source, target);
            RewardPlayer(source, target);
            MoveSourceToTarget(source, target);

            _mergeAnimator.PlayMergeAnimation(source, target, () =>
            {
                var newItem = _itemController.SpawnItems(nextData, mergeCell);
                _beckendHandler.PostItems(newItem);
            });
        }

        private void FreeCells(ItemWeaponView source, ItemWeaponView target)
        {
            source.CurrentCell.MarkAsFree();
            target.CurrentCell.MarkAsFree();

            _beckendHandler.PostSpendItems(source);
            _beckendHandler.PostSpendItems(target);
        }

        private void RewardPlayer(ItemWeaponView source, ItemWeaponView target)
        {
            int totalReward = source.ItemWeaponModel.Reward + target.ItemWeaponModel.Reward;
            _beckendHandler.PostReward(totalReward);
        }

        private void MoveSourceToTarget(ItemWeaponView source, ItemWeaponView target) => 
            source.transform.position = target.transform.position;
    }
}
