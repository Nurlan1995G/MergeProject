using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._Project.Scripts.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private Camera _mainCamera;

        private InputAction _tapAction;
        private InputAction _dragAction;
        private InputAction _releaseAction;

        private ItemWeaponView _draggedItem;

        public event Action<ItemWeaponView, ItemWeaponView> OnMergeRequested;
        public event Action<ItemWeaponView> OnItemClicked;

        public void Construct()
        {
            _playerInput = new PlayerInput();
            _mainCamera = Camera.main;
            _playerInput.Enable();

            SetupInputActions();
            BindInputActions();
        }

        private void OnDisable()
        {
            _tapAction.performed -= OnClick;
            _dragAction.performed -= OnDrag;
            _releaseAction.canceled -= OnRelease;

            _playerInput.Disable();
        }

        private void OnClick(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            Vector2 screenPosition = GetPointerScreenPosition();
            Vector3 worldPosition = ScreenToWorld(screenPosition);

            Collider2D hit = Physics2D.OverlapPoint(worldPosition);

            if (hit != null && hit.TryGetComponent(out ItemWeaponView item))
            {
                OnItemClicked?.Invoke(item);
                _draggedItem = item;
            }
        }

        private void OnDrag(InputAction.CallbackContext context)
        {
            if (_draggedItem == null)
                return;

            Vector2 screenPosition = context.ReadValue<Vector2>();
            Vector3 worldPosition = ScreenToWorld(screenPosition);
            _draggedItem.transform.position = worldPosition;
        }

        private void OnRelease(InputAction.CallbackContext context)
        {
            if (_draggedItem == null) return;

            Collider2D[] hits = Physics2D.OverlapCircleAll(_draggedItem.transform.position, 0.5f);

            ItemWeaponView mergeTarget = hits
                .Select(hit => hit.GetComponent<ItemWeaponView>())
                .FirstOrDefault(item =>
                    item != null &&
                    item != _draggedItem);

            _draggedItem.transform.position = _draggedItem.CurrentCell.transform.position;

            if (mergeTarget != null)
                OnMergeRequested?.Invoke(_draggedItem, mergeTarget);

            _draggedItem = null;
        }

        private void SetupInputActions()
        {
            if (Application.isMobilePlatform)
            {
                _tapAction = _playerInput.PassThrough.Tap;
                _dragAction = _playerInput.PassThrough.TouchPosition;
                _releaseAction = _playerInput.PassThrough.TouchRelease;
            }
            else
            {
                _tapAction = _playerInput.Mouse.MouseTap;
                _dragAction = _playerInput.Mouse.MousePosition;
                _releaseAction = _playerInput.Mouse.MouseRelease;
            }
        }

        private void BindInputActions()
        {
            _tapAction.performed += OnClick;
            _dragAction.performed += OnDrag;
            _releaseAction.canceled += OnRelease;
        }
        
        private Vector2 GetPointerScreenPosition()
        {
            if (Application.isMobilePlatform)
                return Touchscreen.current.primaryTouch.position.ReadValue();
            else
                return Mouse.current.position.ReadValue();
        }

        private Vector3 ScreenToWorld(Vector2 screenPos)
        {
            Vector3 world = _mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Mathf.Abs(_mainCamera.transform.position.z)));
            world.z = 0f;
            return world;
        }
    }
}
