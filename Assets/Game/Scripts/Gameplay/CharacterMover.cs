using Game.Scripts.Core;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class CharacterMover : IInitializable, ITickable
    {
        private IInputService _inputService;
        private PlayerCharacterView _playerCharacterView;
        
        private float _maxSpeed;
        private float _jumpStrength;
        private float _sensitivity;
        private float _maxVerticalAngle;
        
        private Vector3 _velocity;
        private float _currentVerticalAngle = 0.0f;
        private float _gravity = 9.81f;
        
        public CharacterMover(IInputService inputService, PlayerCharacterView playerCharacterView)
        {
            _inputService = inputService;
            _playerCharacterView = playerCharacterView;
            _maxSpeed = _playerCharacterView.MaxSpeed;
            _jumpStrength = _playerCharacterView.JumpStrength;
            _sensitivity = _playerCharacterView.Sensitivity;
            _maxVerticalAngle = _playerCharacterView.MaxVerticalAngle;
            
            _inputService.JumpPressed += Jump;
            _inputService.LookChanged += Rotate;
        }

        public void Initialize()
        {
            _playerCharacterView.transform.parent = null;
        }

        public void Tick()
        {
            ChangeVelocity();
            Move();
        }

        private void Move()
        {
            Vector3 direction = _playerCharacterView.transform.TransformDirection(_velocity);
            _playerCharacterView.CharacterController.Move(direction * Time.deltaTime);
        }

        private void ChangeVelocity()
        {
            _velocity.x = _inputService.Direction.x * _maxSpeed;
            _velocity.z = _inputService.Direction.y * _maxSpeed;
            
            if (_playerCharacterView.CharacterController.isGrounded == false)
                _velocity.y -= _gravity * Time.deltaTime;
        }

        private void Jump()
        {
            if (_playerCharacterView.CharacterController.isGrounded == false)
                return;
            
            _velocity.y = _jumpStrength;
        }

        private void Rotate(Vector2 mouseDelta)
        {
            Vector2 rotationAmount = mouseDelta * _sensitivity;
            
            _playerCharacterView.transform.Rotate(0, rotationAmount.x, 0);
            
            _currentVerticalAngle -= rotationAmount.y;
            _currentVerticalAngle = Mathf.Clamp(_currentVerticalAngle, -_maxVerticalAngle, _maxVerticalAngle);
            _playerCharacterView.Head.localEulerAngles = new Vector3(_currentVerticalAngle, 0.0f, 0.0f);
        }
    }
}