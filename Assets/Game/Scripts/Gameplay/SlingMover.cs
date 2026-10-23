using UnityEngine;

namespace Game.Scripts.Gameplay
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

        public void MoveTo(Vector3 position)
        {
            Move(position);
        }

        public void Drop()
        {
            Reset();
        }

        private void Move(Vector3 position)
        {
            if (Vector3.Distance(_startPosition, position) > _slingView.MaxDistance)
                position = (position - _startPosition).normalized * _slingView.MaxDistance + _startPosition;
            
            _slingView.transform.position = position;
            _slingView.transform.rotation = Quaternion.LookRotation(position - _startPosition) *  Quaternion.Euler(180, -90, 0);
        }
        
        private void Reset()
        {
            _slingView.transform.position = _startPosition;
            _slingView.transform.rotation = _startRotation;
        }
    }
}