using Game.Scripts.Gameplay.Interaction;
using UnityEngine;

namespace Game.Scripts.Gameplay.Sling
{
    public class SlingMover : IPickableMover
    {
        private SlingView _slingView;
        
        private readonly Vector3 _startPosition;
        private readonly Quaternion _startRotation;

        public SlingMover(SlingView slingView)
        {
            _slingView = slingView;
            
            _startPosition = _slingView.transform.position;
            _startRotation = _slingView.transform.rotation;
        }

        public void MoveTo(Transform owner)
        {
            if (Vector3.Distance(_startPosition, owner.position) > _slingView.MaxDistance)
                owner.position = (owner.position - _startPosition).normalized * _slingView.MaxDistance + _startPosition;
            
            _slingView.transform.position = owner.position;
            _slingView.transform.rotation = Quaternion.LookRotation(owner.position - _startPosition) 
                                            * Quaternion.Euler(180, -90, 0);
        }
        
        public void Drop()
        {
            _slingView.transform.position = _startPosition;
            _slingView.transform.rotation = _startRotation;
        }
    }
}