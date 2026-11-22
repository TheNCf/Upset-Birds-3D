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

        public BirdHolder(SlingView slingView)
        {
            _slingView = slingView;

            _slingView.ColliderTriggered += OnColliderTriggered;
        }

        private void OnColliderTriggered(Collider other)
        {
            if (other.TryGetComponent(out BirdView bird))
            {
                _holdedBird?.Drop(_slingView.BirdPlace);
                _holdedBird = bird.Mover;
                _holdedBird.MoveTo(_slingView.BirdPlace.position, _slingView.BirdPlace);
            }
        }
    }
}