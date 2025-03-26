using UnityEngine;

namespace Assets._Project.Scripts
{
    public class AppPresenter : MonoBehaviour
    {
        [SerializeField] private WeaponPresenter _weaponPresenter;
        [SerializeField] private GridPresenter _gridPresenter;

        private void Start()
        {
            Application.targetFrameRate = 60;

            _weaponPresenter.Initialize();
            _gridPresenter.Initialize();
        }
    }
}
