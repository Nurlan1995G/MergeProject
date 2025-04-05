using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.Input;
using Assets._Project.Scripts.Items.Controllers;
using Assets._Project.Scripts.Levels.Controllers;
using Assets._Project.Scripts.ScriptableObjects;
using Assets._Project.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Bootstrapers
{
    public class GameBootstraper : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private LevelController _levelController;
        [SerializeField] private ItemWeaponController _itemsController;
        [SerializeField] private List<LevelData> _levelDatas;
        [SerializeField] private List<CellView> _cells;
        [SerializeField] private PlayerInputHandler _inputHandler;
        [SerializeField] private List<ItemWeaponData> _itemWeaponDatas;
        [SerializeField] private MergeController _mergeController;
        [SerializeField] private GamesBeckendHandler _backendHandler;
        [SerializeField] private MenuController _menuController;

        private void Awake()
        {
            PlayerData playerData = new PlayerData();
            
            HandlePlayerItemWeapon();
            HandlePlayerBalance();

            _menuController.Construct(playerData);
            _menuController.ShowBalancePlayer();

            _inputHandler.Construct();
            _itemsController.Initialize(_gameConfig.LevelData);
            _levelController.Initialize(_itemsController, _cells, _itemWeaponDatas);
            _mergeController.Initialize(_itemsController, _itemWeaponDatas, _inputHandler);
        }

        private void HandlePlayerItemWeapon()
        {
            _backendHandler.GetItemWeapon(
            {
                
            });
        }

        private void HandlePlayerBalance()
        {
            _backendHandler.GetBalance(
            {
                
            });
        }
    }
}
