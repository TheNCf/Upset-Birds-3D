using Game.Scripts.Gameplay.Birds.Data;
using UnityEngine;

namespace Game.Scripts.Gameplay.Birds
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
            birdView.gameObject.layer = LayerMaskToLayer(data.LayerMask);
            GameObject.Instantiate(data.Visuals, bird.transform);
            return birdView;
        }

        private int LayerMaskToLayer(LayerMask mask)
        {
            int bitmask = mask.value;
            
            if (bitmask == 0)
                return 0;
            
            int result = bitmask > 0 ? 0 : 31;

            while (bitmask > 1)
            {
                bitmask >>= 1;
                result++;
            }

            return result;
        }
    }
}