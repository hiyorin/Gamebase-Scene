#if GAMEBASE_ADD_NODECANVAS
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Scene.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("Initialize Scene Manager")]
    [Category("✫ Gamebase/SceneManagement")]
    public sealed class InitializeSceneManager : ActionTask<SceneManagementTaskManager>
    {
        protected override void OnExecute()
        {
            agent.Controller.Initialize().GetAwaiter().OnCompleted(() => EndAction(true));
        }
    }
}
#endif