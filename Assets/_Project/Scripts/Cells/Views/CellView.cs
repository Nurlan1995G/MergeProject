using UnityEngine;

namespace Assets._Project.Scripts.Cells
{
    public class CellView : MonoBehaviour
    {
        private bool _isBusy;
        private ItemWeaponView _currentItem;

        public bool IsBusy => _isBusy;

        public Vector3 GetPlaceItem(ItemWeaponView item)
        {
            if (!_isBusy && item.CurrentCell == null)
            {
                _isBusy = true;
                item.SetCurrentCell(this);
                return transform.position;
            }

            return Vector3.zero;
        }

        public void MarkAsBusy()
        {
            if (!_isBusy)
                _isBusy = true;
        }

        public void MarkAsFree()
        {
            if (_isBusy)
                _isBusy = false;
        }
    }
}
