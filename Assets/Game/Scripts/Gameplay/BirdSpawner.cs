using System.Collections.Generic;
using Game.Scripts.Gameplay.ScriptableObjects;
using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class BirdSpawner
    {
        private BirdSpawnerView _view;

        private int _birdCount = 0;
        
        public BirdSpawner(BirdSpawnerView view)
        {
            _view = view;
            
            InstantiateBirds();
        }

        private void InstantiateBirds()
        {
            BirdFactory factory = new BirdFactory();
            
            foreach (var bird in _view.Birds)
            {
                Vector3 spawnPosition = _view.transform.position + _view.transform.right * 
                    _view.DistanceBetweenBirds * _birdCount;
                
                factory.Create(bird, spawnPosition);
                _birdCount++;
            }
        }
    }
}