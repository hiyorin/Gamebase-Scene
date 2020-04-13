#if GAMEBASE_ADD_NODECANVAS
using System;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UniRx;

namespace Gamebase.Scene.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("Change Scene")]
    [Category("✫ Gamebase/SceneManagement")]
    public sealed class ChangeScene : ActionTask<SceneManagementTaskManager>
    {
        [RequiredField] public BBParameter<string> sceneName = default;

        [BlackboardOnly] public BBParameter<object> transData = default;
        
        private IDisposable disposable;

        protected override string info => $"Change Scene {sceneName}";

        protected override void OnExecute()
        {
            disposable?.Dispose();
            disposable = agent.Controller.OnTransCompleteAsObservable()
                .Subscribe(_ => EndAction(true));
            agent.Controller.Change(sceneName.value, transData.value);
        }

        protected override void OnStop()
        {
            disposable?.Dispose();
            disposable = null;
            base.OnStop();
        }
    }
}
#endif