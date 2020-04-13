#if GAMEBASE_ADD_NODECANVAS
using Gamebase.Scene.NodeCanvas.Signals;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Scene.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("Change Scene Request")]
    [Category("✫ Gamebase/Scene")]
    public sealed class ChangeSceneRequest : ActionTask<SceneTaskManager>
    {
        [RequiredField] public BBParameter<string> sceneName = default;
        
        [BlackboardOnly] public BBParameter<object> transData = default;

        protected override string info => $"{base.info} {sceneName}";

        protected override void OnExecute()
        {
            agent.SignalBus.Fire(new ChangeSceneSignal(sceneName.value, transData.value));
            EndAction(true);
        }
    }
}
#endif