using Game.Scripts.Gameplay.Interaction;
using UnityEngine;

namespace Game.Scripts.Gameplay.Birds
{
    public class BirdMover : IPickableMover
    {
        private BirdView _view;
        
        private Transform _owner;

        public BirdMover(BirdView view)
        {
            _view = view;
        }

        public void MoveTo(Vector3 position, Transform owner)
        {
            if (_owner == null)
            {
                _owner = owner;
                _view.transform.parent = _owner;
                _view.Rigidbody.velocity = Vector3.zero;
                _view.Rigidbody.angularVelocity = Vector3.zero;
                _view.Rigidbody.useGravity = false;
                _view.Collider.isTrigger = true;
            }
            
            if (_owner.Equals(owner) == false)
                return;
            
            _view.transform.position = position;
        }

        public void Drop(Transform owner)
        {
            if (owner.Equals(_owner) == false)
                return;
            
            _view.transform.parent = null;
            _view.Rigidbody.useGravity = true;
            _view.Collider.isTrigger = false;
            
            _owner = null;
            
            Debug.Log("Dropped Bird");
        }
    }
}