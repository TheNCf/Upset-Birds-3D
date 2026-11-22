using Game.Scripts.Gameplay.Interaction;
using UnityEngine;

namespace Game.Scripts.Gameplay.Birds
{
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
    public class BirdView : MonoBehaviour, IPickableView
    {
        public Rigidbody Rigidbody { get; private set; }
        public SphereCollider Collider { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<SphereCollider>();
            
            Mover = new BirdMover(this);
        }

        public IPickableMover Mover { get; private set; }
    }
}