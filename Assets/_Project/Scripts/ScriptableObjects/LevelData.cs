using Assets._Project.Scripts.Cells;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level/Data")]
    public class LevelData : ScriptableObject
    {
        [Header("Grid Configuration")]
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;

        [Header("Game Objects")]
        [SerializeField] private CellView _cellPrefab;

        [Header("Size Objects")]
        [SerializeField] private float _sizeCell = 0.5f;
        [SerializeField] private float _sizeItem = 0.5f;

        public CellView CellPrefab => _cellPrefab;
        public int Rows => _rows;
        public int Colums => _columns;
        public float SizeCell => _sizeCell;
        public float SizeItem => _sizeItem;

        public int LevelIndex = 1;
    }
}
