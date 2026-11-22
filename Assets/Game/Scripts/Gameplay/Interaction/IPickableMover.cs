using UnityEngine;

namespace Game.Scripts.Gameplay.Interaction
{
    public interface IPickableMover
    {
        void MoveTo(Vector3 position, Transform owner);

        void Drop(Transform owner);
    }
}