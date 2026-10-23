using System;
using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class SlingView : MonoBehaviour, IPickableView
    {
        [field: SerializeField] public float MaxDistance { get; private set; }

        public IPickableMover PickableMover { get; private set; }

        private void Awake()
        {
            PickableMover = new SlingMover(this);
        }
    }
}