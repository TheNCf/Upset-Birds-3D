using UnityEngine;

namespace Game.Scripts.Gameplay.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Game/BirdData")]
    public class BirdData : ScriptableObject
    {
        [field: SerializeField] public float StartSpeed { get; private set; }
        [field: SerializeField] public float Mass { get; private set; }
        [field: SerializeField] public float ColliderRadius { get; private set; }
        [field: SerializeField] public BirdType Type { get; private set; }
        [field: SerializeField] public GameObject Visuals { get; private set; }
    }
}