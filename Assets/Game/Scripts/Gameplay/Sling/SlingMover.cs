using Game.Scripts.Gameplay.Interaction;
using UnityEngine;

namespace Game.Scripts.Gameplay.Sling
{
    public class SlingMover : IPickableMover
    {
        private SlingView _slingView;
        
        private readonly Vector3 _startPosition;
        private readonly Quaternion _startRotation;

        private Transform _owner = null;

        public SlingMover(SlingView slingView)
        {
            _slingView = slingView;
            
            _startPosition = _slingView.transform.position;
            _startRotation = _slingView.transform.rotation;
        }

        public void MoveTo(Vector3 position, Transform owner)
        {
            if (_owner == false)
                _owner = owner;
            
            if (_owner.Equals(owner) == false)
                return;
            
            if (Vector3.Distance(_startPosition, position) > _slingView.MaxDistance)
                position = (position - _startPosition).normalized * _slingView.MaxDistance + _startPosition;
            
            _slingView.transform.position = position;
            _slingView.transform.rotation = Quaternion.LookRotation(position - _startPosition) *  Quaternion.Euler(180, -90, 0);
        }
        
        public void Drop(Transform owner)
        {
            if (owner.Equals(_owner) == false)
                return;
            
            _slingView.transform.position = _startPosition;
            _slingView.transform.rotation = _startRotation;
            
            _owner = null;
        }
    }
}