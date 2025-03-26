using System;

namespace Assets._Project.Scripts
{
    [Serializable]
    public class GridModel
    {
        private int _width;
        private int _height;
        private ItemWeapon[,] _grid;

        public GridModel(int width, int height)
        {
            _width = width;
            _height = height;
            _grid = new ItemWeapon[_width, _height];
        }
    }
}