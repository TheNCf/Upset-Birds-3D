using Game.Scripts.Gameplay.Interaction;
using UnityEngine;

namespace Game.Scripts.Gameplay.Birds
{
    public class BirdMover : IPickableMover
    {
        private BirdView _view;

        public BirdMover(BirdView view)
        {
            _view = view;
        }

        public void MoveTo(Transform owner)
        {
            _view.Rigidbody.velocity = Vector3.zero;
            _view.Rigidbody.angularVelocity = Vector3.zero;
            _view.Rigidbody.useGravity = false;
            _view.Collider.enabled = false;

            _view.transform.position = owner.position;
            _view.transform.parent = owner;
        }

        public void Drop()
        {
            _view.Rigidbody.useGravity = true;
            _view.Collider.enabled = true;
            _view.transform.parent = null;
        }
    }
}