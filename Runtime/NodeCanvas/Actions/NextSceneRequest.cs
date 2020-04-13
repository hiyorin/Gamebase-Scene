#if GAMEBASE_ADD_NODECANVAS
using Gamebase.Scene.NodeCanvas.Signals;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Scene.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("Next Scene Request")]
    [Category("✫ Gamebase/Scene")]
    public sealed class NextSceneRequest : ActionTask<SceneTaskManager>
    {
        protected override void OnExecute()
        {
            agent.SignalBus.Fire(new NextSceneSignal());
            EndAction(true);
        }
    }
}
#endif