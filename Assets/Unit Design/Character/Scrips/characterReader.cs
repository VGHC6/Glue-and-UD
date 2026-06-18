using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UD
{
    [Serializable]
    public class characterReader
    {
        [SerializeField] GameControl _gameControl;
        [field: SerializeField] public Vector2 Move { get; private set; } //ÒÆ¶¯
        [field: SerializeField] public Vector2 Look { get; private set; } //Ðý×ª

        public event Action OnPausePression;
        public void OnAwake()
        {
            _gameControl = new GameControl();
            InputSystem.EnableDevice(Mouse.current);
        }


        public void OnEnable()
        {
            _gameControl.Enable();
            _gameControl.Player.Move.performed += OnMove;
            _gameControl.Player.Look.performed += OnLook;
            _gameControl.Player.Move.canceled += OnMoveCancel;
            _gameControl.Player.Look.canceled += OnLookCancel;
            _gameControl.UI.Cancel.performed += OnPause;
        }

        public void OnDisable()
        {
            _gameControl.Disable();
            _gameControl.Player.Move.performed -= OnMove;
            _gameControl.Player.Look.performed -= OnLook;
            _gameControl.Player.Move.canceled -= OnMoveCancel;
            _gameControl.Player.Look.canceled -= OnLookCancel;
            _gameControl.UI.Cancel.performed -= OnPause;
        }

        public void OnDisablePlayerInput()
        {
            _gameControl.Player.Disable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void OnEnablePlayerInput()
        {
            _gameControl.Player.Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        void OnMove(InputAction.CallbackContext context) => Move = context.ReadValue<Vector2>();
        void OnLook(InputAction.CallbackContext context) => Look = context.ReadValue<Vector2>();
        void OnMoveCancel(InputAction.CallbackContext context) => Move = Vector2.zero;
        void OnLookCancel(InputAction.CallbackContext context) => Look = Vector2.zero;
        void OnPause(InputAction.CallbackContext context) => OnPausePression?.Invoke();
    }
}