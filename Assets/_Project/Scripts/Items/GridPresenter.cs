using UnityEngine;

namespace Assets._Project.Scripts
{
    public class GridPresenter : MonoBehaviour
    {
        private GridModel _gridModel;

        public void Initialize()
        {
            _gridModel = new GridModel(5, 5); // Размер поля 5x5, можно изменить
        }
    }
}