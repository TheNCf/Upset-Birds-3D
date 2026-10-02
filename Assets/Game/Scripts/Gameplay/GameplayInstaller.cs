using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCharacterView _playerCharacterPrefab;
        [SerializeField] private Transform _playerCharacterSpawnPoint;
        
        public override void InstallBindings()
        {
            BindPlayerCharacterView();
            BindCharacterMover();
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
                .BindInterfacesAndSelfTo<CharacterMover>()
                .AsSingle()
                .NonLazy();
        }
    }
}