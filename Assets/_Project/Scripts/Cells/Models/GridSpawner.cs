using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Cells
{
    public class GridSpawner
    {
        private readonly CellFactory _cellFactory;
        private readonly GridManagerModel _gridManagerModel;

        public GridSpawner(CellFactory cellFactory, GridManagerModel gridManagerModel)
        {
            _cellFactory = cellFactory;
            _gridManagerModel = gridManagerModel;
        }

        public List<CellView> SpawnCells(int rows, int columns)
        {
            List<Vector3> positions = _gridManagerModel.GetCellPositions(rows, columns);
            List<CellView> cells = new List<CellView>();

            foreach (var position in positions)
            {
                CellView cell = _cellFactory.CreateCell(position);
                cells.Add(cell);
            }

            return cells;
        }
    }
}
