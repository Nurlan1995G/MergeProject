using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._Project.Scripts.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private Camera _mainCamera;
        private InputAction _currentTapAction;

        public event Action<ItemWeaponView> OnItemClicked;

        public void Construct()
        {
            _playerInput = new PlayerInput();
            _mainCamera = Camera.main;
            _playerInput.Enable();

            if (Application.isMobilePlatform)
                _currentTapAction = _playerInput.PassThrough.Tap;
            else
                _currentTapAction = _playerInput.Mouse.MouseTap;

            _currentTapAction.performed += OnClick;
        }

        private void OnDisable()
        {
            if (_currentTapAction != null)
                _currentTapAction.performed -= OnClick;

            _playerInput.Disable();
        }

        private void OnClick(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            Vector2 inputPosition;

            if (Application.isMobilePlatform)
                inputPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            else
                inputPosition = Mouse.current.position.ReadValue();

            Vector2 worldPosition = _mainCamera.ScreenToWorldPoint(inputPosition);
            Collider2D hit = Physics2D.OverlapPoint(worldPosition);

            if (hit != null && hit.TryGetComponent(out ItemWeaponView item))
            {
                Debug.Log($"Подобран предмет: {item.ItemWeaponModel.ItemType}");
                OnItemClicked?.Invoke(item);
            }
        }
    }
}
