using System;
using Game.Scripts.Core;
using Game.Scripts.Gameplay.Interaction;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.Player
{
    public class PlayerCharacterPicker : ITickable, IDisposable
    {
        private PlayerCharacterView _view;
        private InputService _input;
        
        private IPickableMover _pickableMover;

        public PlayerCharacterPicker(PlayerCharacterView view, InputService input)
        {
            _view = view;
            _input = input;
            
            _input.UsingStarted += OnUseStart;
            _input.UsingStopped += OnUseStop;
        }

        public void Tick()
        {
            MoveToHands();
        }

        public void Dispose()
        {
            _input.UsingStarted -= OnUseStart;
            _input.UsingStopped -= OnUseStop;
        }

        private void MoveToHands()
        {
            _pickableMover?.MoveTo(_view.ObjectHolder);
        }

        private void OnUseStart()
        {
            Ray ray = new Ray(_view.Head.position, _view.Head.forward);
            
            if (Physics.Raycast(ray, out RaycastHit hit, _view.ReachDistance, _view.InteractionLayerMask) == false)
                return;

            if (hit.collider.TryGetComponent(out IPickableView pickableView))
                _pickableMover = pickableView.Mover;
        }

        private void OnUseStop()
        {
            if (_pickableMover == null)
                return;
            
            _pickableMover.Drop();
            _pickableMover = null;
        }
    }
}