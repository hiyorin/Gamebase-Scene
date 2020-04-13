#if GAMEBASE_ADD_NODECANVAS
using Gamebase.Scene.NodeCanvas.Signals;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Scene.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("Return Scene Request")]
    [Category("✫ Gamebase/Scene")]
    public sealed class ReturnSceneRequest : ActionTask<SceneTaskManager>
    {
        protected override void OnExecute()
        {
            agent.SignalBus.Fire(new ReturnSceneSignal());
            EndAction(true);
        }   
    }
}
#endif