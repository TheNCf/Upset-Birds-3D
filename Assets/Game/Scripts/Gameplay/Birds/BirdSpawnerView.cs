using System.Collections.Generic;
using Game.Scripts.Gameplay.Birds.Data;
using UnityEngine;

namespace Game.Scripts.Gameplay.Birds
{
    public class BirdSpawnerView : MonoBehaviour
    {
        public IReadOnlyList<BirdData> Birds => birds;
        
        [field: SerializeField] public float DistanceBetweenBirds { get; private set; }
        
        [SerializeField] private List<BirdData> birds;
    }
}