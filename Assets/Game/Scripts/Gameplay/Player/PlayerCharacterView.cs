using UnityEngine;

namespace Game.Scripts.Gameplay.Player
{
    public class PlayerCharacterView : MonoBehaviour
    {
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
        [field: SerializeField] public Transform Head { get; private set; }
        [field: SerializeField] public Transform ObjectHolder { get; private set; }
        [field: SerializeField] public float MaxSpeed { get; private set; } = 5f;
        [field: SerializeField] public float JumpStrength { get; private set; } = 5f;
        [field: SerializeField] public float Sensitivity { get; private set; } = 3f;
        [field: SerializeField] public float MaxVerticalAngle { get; private set; } = 85f;
        [field: SerializeField] public LayerMask InteractionLayerMask { get; private set; }
        [field: SerializeField] public float ReachDistance { get; private set; } = 5f;
    }
}
