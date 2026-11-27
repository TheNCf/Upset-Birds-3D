using UnityEngine;

namespace Game.Scripts.Gameplay.Interaction
{
    public interface IPickableMover
    {
        void MoveTo(Transform owner);

        void Drop();
    }
}