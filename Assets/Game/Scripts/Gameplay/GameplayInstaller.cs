using Game.Scripts.Gameplay.Birds;
using Game.Scripts.Gameplay.Player;
using Game.Scripts.Gameplay.Sling;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCharacterView _playerCharacterPrefab;
        [SerializeField] private Transform _playerCharacterSpawnPoint;
        [Space(10)]
        [SerializeField] private BirdSpawnerView _birdSpawnerView;
        [SerializeField] private SlingView _slingView;


        public override void InstallBindings()
        {
            BindPlayerCharacterView();
            BindSlingView();
            BindBirdSpawnerView();
            
            BindCharacterMover();
            BindPlayerCharacterInteractor();
            
            BindBirdSpawner();
        }

        private void BindBirdSpawner()
        {
            Container
                .BindInterfacesAndSelfTo<BirdSpawner>()
                .AsSingle()
                .NonLazy();
        }

        private void BindBirdSpawnerView()
        {
            Container
                .Bind<BirdSpawnerView>()
                .FromInstance(_birdSpawnerView)
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerCharacterInteractor()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerCharacterPicker>()
                .AsSingle()
                .NonLazy();
        }

        private IfNotBoundBinder BindSlingView()
        {
            return Container
                .Bind<SlingView>()
                .FromInstance(_slingView)
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerCharacterView()
        {
            Container
                .Bind<PlayerCharacterView>()
                .FromComponentInNewPrefab(_playerCharacterPrefab)
                .UnderTransform(_playerCharacterSpawnPoint)
                .AsSingle()
                .NonLazy();
        }

        private void BindCharacterMover()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerCharacterMover>()
                .AsSingle()
                .NonLazy();
        }
    }
}