using System;
using UnityEngine;
using UnityEngine.InputSystem;
namespace GLUE
{
    public class ActionRader : MonoBehaviour
    {
        [SerializeField] GameControl _gameControl;
        [field: SerializeField] public Vector2 Move { get; private set; } //ÒÆ¶¯
        [field: SerializeField] public Vector2 Look { get; private set; } //Ðý×ª

        private void Awake()
        {
            _gameControl = new GameControl();
        }

        private void OnEnable()
        {
            _gameControl.Enable();
            _gameControl.Player.Move.performed += OnMove;
            _gameControl.Player.Look.performed += OnLook;
            _gameControl.Player.Move.canceled += OnMoveCancel;
            _gameControl.Player.Look.canceled += OnLookCancel;
        }

        private void OnDisable()
        {
            _gameControl.Disable();
            _gameControl.Player.Move.performed -= OnMove;
            _gameControl.Player.Look.performed -= OnLook;
            _gameControl.Player.Move.canceled -= OnMoveCancel;
            _gameControl.Player.Look.canceled -= OnLookCancel;
        }

        void OnMove(InputAction.CallbackContext context) => Move = context.ReadValue<Vector2>();
        void OnLook(InputAction.CallbackContext context) => Look = context.ReadValue<Vector2>();
        void OnMoveCancel(InputAction.CallbackContext context) => Move = Vector2.zero;
        void OnLookCancel(InputAction.CallbackContext context) => Look = Vector2.zero;
    }
}