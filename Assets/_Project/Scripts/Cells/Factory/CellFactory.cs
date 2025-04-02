using Assets._Project.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets._Project.Scripts.Cells
{
    public class CellFactory
    {
        private readonly CellView _cellPrefab;

        public CellFactory(LevelData levelData)
        {
            _cellPrefab = levelData.CellPrefab;
        }

        public CellView CreateCell(Vector3 parent)
        {
            CellView cell = Object.Instantiate(_cellPrefab, parent, Quaternion.identity);
            return cell;
        }
    }
}
