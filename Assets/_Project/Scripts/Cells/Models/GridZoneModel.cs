using Assets._Project.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets._Project.Scripts.Cells
{
    public class GridZoneModel
    {
        private ManagerData _managerData;
        private LevelData _levelData;
        private Vector3 _startPosition;

        public GridZoneModel(GameConfig gameConfig)
        {
            _managerData = gameConfig.ManagerData;
            _levelData = gameConfig.LevelData;
            _startPosition = _managerData.StartPosition;
        }

        public Vector3 GetCellPosition(int row, int col)
        {
            Vector3 startPos = new Vector3(
                _startPosition.x - (_levelData.Colums - 1) / 2f * _levelData.SizeCell,
                _startPosition.y + (_levelData.Rows - 1) / 2f * _levelData.SizeCell,
                _startPosition.z);

            float xPos = startPos.x + col * _levelData.SizeCell;
            float yPos = startPos.y - row * _levelData.SizeCell;

            return new Vector3(xPos, yPos, _startPosition.z);
        }
    }
}
