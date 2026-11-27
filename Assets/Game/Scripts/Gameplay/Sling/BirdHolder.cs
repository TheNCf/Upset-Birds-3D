using Game.Scripts.Gameplay.Birds;
using Game.Scripts.Gameplay.Interaction;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.Sling
{
    public class BirdHolder
    {
        private SlingView _slingView;

        private IPickableMover _holdedBird;
        private IPickableMover _lastBird;

        public BirdHolder(SlingView slingView)
        {
            _slingView = slingView;

            _slingView.ColliderTriggered += OnColliderTriggered;
        }

        private void OnColliderTriggered(Collider other)
        {
            if (other.TryGetComponent(out BirdView bird))
            {
                if (bird.Mover == _lastBird)
                {
                    _lastBird = null;
                    return;
                }
                
                _lastBird = _holdedBird;
                _holdedBird?.Drop();
                _holdedBird = bird.Mover;
                _holdedBird.MoveTo(_slingView.BirdPlace);
            }
        }
    }
}