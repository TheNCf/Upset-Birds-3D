using Game.Scripts.Gameplay.ScriptableObjects;
using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class BirdFactory
    {
        public BirdView Create(BirdData data, Vector3 position)
        {
            GameObject bird = new();
            bird.name = data.Type.ToString();
            bird.transform.position = position;
            BirdView birdView = (BirdView)bird.AddComponent(typeof(BirdView));
            birdView.Rigidbody.mass = data.Mass;
            birdView.Collider.radius = data.ColliderRadius;
            GameObject.Instantiate(data.Visuals, bird.transform);
            return birdView;
        }
    }
}