using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public interface IPickableMover
    {
        void MoveTo(Vector3 position);

        void Drop();
    }
}