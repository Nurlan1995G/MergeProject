using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Cells
{
    public class GridManagerModel
    {
        private GridZoneModel _gridZone;

        public GridManagerModel(GameConfig gameConfig)
        {
            _gridZone = new GridZoneModel(gameConfig);
        }

        public List<Vector3> GetCellPositions(int rows, int columns)
        {
            var positions = new List<Vector3>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                    positions.Add(_gridZone.GetCellPosition(row, col));
            }

            return positions;
        }
    }
}
