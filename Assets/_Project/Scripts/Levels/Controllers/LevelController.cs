using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.Items.Controllers;
using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Scripts.Levels.Controllers
{
    public class LevelController : MonoBehaviour
    {
        private LevelData _currentLevelData;

        public void Initialize(List<LevelData> levels, CellsController cellsController, ItemsController itemsController, List<CellView> cells)
        {
            _currentLevelData = levels[0];

            List<Vector3> cellPositions = cells.Select(cell => cell.transform.position).ToList();

            if (_currentLevelData.LevelIndex == 1)
            {
                SpawnFirstLevelItems(itemsController, cellPositions);
            }
        }

        private void SpawnFirstLevelItems(ItemsController itemsController, List<Vector3> cellPositions)
        {
            if (cellPositions.Count < 2) 
                return;

            List<Vector3> selectedPositions = cellPositions.OrderBy(x => Random.value).Take(2).ToList();

            itemsController.SpawnItem(selectedPositions);
        }
    }
}
