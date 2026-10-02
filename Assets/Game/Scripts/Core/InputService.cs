using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Scripts.Core
{
    public class InputService : IInputService, IInitializable, IDisposable
    {
        private InputActions _input = new InputActions();
        
        public event Action JumpPressed;
        public event Action<Vector2> LookChanged;
        public Vector2 Direction { get; private set; }
        public bool IsUsing { get; private set; }

        public void Initialize()
        {
            SubscribeToEvents();
        }

        public void Dispose()
        {
            UnsubscribeToEvents();
        }
    
        private void SubscribeToEvents()
        {
            _input.Enable();

            _input.Player.Jump.started += OnJump;
            _input.Player.Look.performed += OnLook;
            _input.Player.Move.started += OnMove;
            _input.Player.Move.performed += OnMove;
            _input.Player.Move.canceled += OnMove;
            _input.Player.Use.started += OnUse;
            _input.Player.Use.canceled += OnUse;
        }

        private void UnsubscribeToEvents()
        {
            _input.Disable();
        
            _input.Player.Jump.started -= OnJump;
            _input.Player.Look.performed -= OnLook;
            _input.Player.Move.started -= OnMove;
            _input.Player.Move.performed -= OnMove;
            _input.Player.Move.canceled -= OnMove;
            _input.Player.Use.started -= OnUse;
            _input.Player.Use.canceled -= OnUse;
        }

        private void OnLook(InputAction.CallbackContext obj)
        {
            LookChanged?.Invoke(obj.ReadValue<Vector2>());
        }

        private void OnUse(InputAction.CallbackContext obj)
        {
            IsUsing = obj.ReadValueAsButton();
        }

        private void OnMove(InputAction.CallbackContext obj)
        {
            Direction = obj.ReadValue<Vector2>().normalized;
        }

        private void OnJump(InputAction.CallbackContext obj)
        {
            JumpPressed?.Invoke();
        }
    }
}