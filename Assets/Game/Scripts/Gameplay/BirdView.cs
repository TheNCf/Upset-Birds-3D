using System;
using UnityEngine;

namespace Game.Scripts.Gameplay
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
        }

        public IPickableMover PickableMover { get; }
    }
}