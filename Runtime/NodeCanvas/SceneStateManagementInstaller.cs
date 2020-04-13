#if GAMEBASE_ADD_NODECANVAS
using Gamebase.Scene.NodeCanvas.Signals;
using Zenject;

namespace Gamebase.Extensions.NodeCanvas.NodeStates
{
    public sealed class SceneStateManagementInstaller : MonoInstaller<SceneStateManagementInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<ChangeSceneSignal>();
            Container.DeclareSignal<NextSceneSignal>();
            Container.DeclareSignal<ReturnSceneSignal>();
        }
    }
}
#endif