using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Cells
{
    public class CellsController : MonoBehaviour
    {
        private List<CellView> _cellViews = new List<CellView>();
        private GameConfig _gameConfig;
        private GridManagerModel _gridManagerModel;
        private GridSpawner _gridSpawner;

        public void Initialize(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;

            CellFactory cellFactory = new CellFactory(_gameConfig.LevelData);
            _gridManagerModel = new GridManagerModel(_gameConfig);
            _gridSpawner = new GridSpawner(cellFactory, _gridManagerModel);

        }

        public List<CellView> SpawnCells(int row, int column)
        {
            List<CellView> cellViews;
            cellViews = _gridSpawner.SpawnCells(row, column);
            return cellViews;
        }
    }
}
