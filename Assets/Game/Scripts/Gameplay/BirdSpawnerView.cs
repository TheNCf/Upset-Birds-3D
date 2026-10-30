using System.Collections.Generic;
using Game.Scripts.Gameplay.ScriptableObjects;
using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class BirdSpawnerView : MonoBehaviour
    {
        public IReadOnlyList<BirdData> Birds => birds;
        
        [field: SerializeField] public float DistanceBetweenBirds { get; private set; }
        
        [SerializeField] private List<BirdData> birds;
    }
}