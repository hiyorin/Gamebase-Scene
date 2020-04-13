#if GAMEBASE_ADD_NODECANVAS
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Scene.NodeCanvas.Conditions
{
    [PublicAPI]
    [Name("Check Scene Initialized")]
    [Category("✫ Gamebase/SceneManagement")]
    public sealed class CheckSceneInitialized : ConditionTask<SceneManagementTaskManager>
    {
        protected override bool OnCheck()
        {
            return agent.Controller.Initialized;
        }
    }
}
#endif