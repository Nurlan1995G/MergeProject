using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.Input;
using Assets._Project.Scripts.Items.Controllers;
using Assets._Project.Scripts.Levels.Controllers;
using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Bootstrapers
{
    public class GameBootstraper : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private LevelController _levelController;
        [SerializeField] private CellsController _cellsController;
        [SerializeField] private ItemsController _itemsController;
        [SerializeField] private List<LevelData> _levelDatas;
        [SerializeField] private List<CellView> _cells;
        [SerializeField] private PlayerInputHandler _inputHandler;

        private void Awake()
        {
            //_cellsController.Initialize(_gameConfig);
            _inputHandler.Construct();
            _itemsController.Initialize(_gameConfig.LevelData);
            _levelController.Initialize(_levelDatas, _cellsController, _itemsController, _cells);
        }
    }
}
