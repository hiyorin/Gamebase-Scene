using Gamebase.Scene.Internal;
using Gamebase.Component;
using UnityEngine;
using Zenject;

namespace Gamebase.Scene
{
    public sealed class SceneManagementInstaller : MonoInstaller<SceneManagementInstaller>
    {
        [SerializeField] private SceneGeneralSettings generalSettings = default;

        [SerializeField] private SceneTransSettings transSettings = default;
        
        [SerializeField] private CanvasGroupFader transition = default;
        
        public override void InstallBindings()
        {
            var subContainer = Container.CreateSubContainer();
            InstallSubContainer(subContainer);
            
            Container.BindInterfacesTo<SceneController>()
                .FromSubContainerResolve()
                .ByInstance(subContainer)
                .AsSingle();
        }

        private void InstallSubContainer(DiContainer subContainer)
        {
            // Constants
            subContainer.BindInstance(generalSettings).AsSingle();
            subContainer.BindInstance(transSettings).AsSingle();
            subContainer.BindInstance(transition).AsSingle();
            
            // ISceneController
            subContainer.Bind<SceneController>().AsSingle();
        }
    }
}