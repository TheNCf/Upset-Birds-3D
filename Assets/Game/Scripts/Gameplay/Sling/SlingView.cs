using System;
using Game.Scripts.Gameplay.Interaction;
using UnityEngine;

namespace Game.Scripts.Gameplay.Sling
{
    public class SlingView : MonoBehaviour, IPickableView
    {
        [field: SerializeField] public float MaxDistance { get; private set; }
        [field: SerializeField] public Transform BirdPlace { get; private set; }

        private BirdHolder _birdHolder;
        
        public event Action<Collider> ColliderTriggered;
        
        public IPickableMover Mover { get; private set; }

        private void Awake()
        {
            Mover = new SlingMover(this);
            _birdHolder = new BirdHolder(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            ColliderTriggered?.Invoke(other);
        }
    }
}