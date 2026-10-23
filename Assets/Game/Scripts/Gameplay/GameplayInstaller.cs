using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCharacterView _playerCharacterPrefab;
        [SerializeField] private Transform _playerCharacterSpawnPoint;
        [Space(10)]
        [SerializeField] private SlingView _slingView;
        
        public override void InstallBindings()
        {
            BindPlayerCharacterView();
            BindCharacterMover();
            
            BindSlingView();
            
            BindPlayerCharacterInteractor();
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