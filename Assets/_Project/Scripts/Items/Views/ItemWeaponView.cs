using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public class ItemWeaponView : MonoBehaviour
    {
        private CellView _currentCell;
        private ItemWeaponModel _weaponModel;

        public CellView CurrentCell => _currentCell;
        public ItemWeaponModel ItemWeaponModel => _weaponModel;

        public void SetCurrentCell(CellView cell) => 
            _currentCell = cell;

        public void CreateModel(ItemWeaponModel model)
        {
            _weaponModel = model;
        }
    }
}
