using Zenject;

namespace Game.Scripts.Core
{
    public class CoreInstaller : MonoInstaller<CoreInstaller>
    {
        public override void InstallBindings()
        {
            BindInputService();
        }

        private void BindInputService()
        {
            Container
                .BindInterfacesAndSelfTo<InputService>()
                .AsSingle()
                .NonLazy();
        }
    }
}