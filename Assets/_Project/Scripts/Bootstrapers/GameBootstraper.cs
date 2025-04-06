using Assets._Project.Scripts.BackendService;
using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.Input;
using Assets._Project.Scripts.Items.Controllers;
using Assets._Project.Scripts.Levels.Controllers;
using Assets._Project.Scripts.ScriptableObjects;
using Assets._Project.Scripts.Service;
using Assets._Project.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Bootstrapers
{
    public class GameBootstraper : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private LevelController _levelController;
        [SerializeField] private List<LevelData> _levelDatas;
        [SerializeField] private List<CellView> _cells;
        [SerializeField] private PlayerInputHandler _inputHandler;
        [SerializeField] private List<ItemWeaponData> _itemWeaponDatas;
        [SerializeField] private MergeController _mergeController;
        [SerializeField] private GamesBeckendHandler _backendHandler;
        [SerializeField] private MenuController _menuController;
        [SerializeField] private MergeAnimator _mergeAnimator;
        
        private IItemWeaponController _itemController;

        private void Start() => 
            _backendHandler.Initialize(OnBackendInitialized);

        private void OnBackendInitialized()
        {
            RegisterControllers();

            _menuController.Construct(_backendHandler);
            HandlePlayerBalance();

            _levelController.Initialize(_itemController, _cells, _itemWeaponDatas, _backendHandler);
            _inputHandler.Construct();
            _mergeController.Initialize(_itemController, _itemWeaponDatas, _inputHandler, _backendHandler, _mergeAnimator);
            HandlePlayerItemWeapon();
        }

        private void RegisterControllers()
        {
            var itemController = new ItemWeaponController();
            ServiceLocator.Instance.RegisterSingle<IItemWeaponController>(itemController);
            _itemController = itemController;
        }

        private void HandlePlayerItemWeapon()
        {
            _backendHandler.GetItems(items =>
            {
                if (items.Count == 0)
                    _levelController.SpawnInitialItems(_backendHandler);
                else
                    _levelController.RestoreItems(items);
            });
        }

        private void HandlePlayerBalance()
        {
            _backendHandler.GetBalance(balance =>
            {
                _menuController.UpdateBalance(balance);
            });
        }
    }
}
