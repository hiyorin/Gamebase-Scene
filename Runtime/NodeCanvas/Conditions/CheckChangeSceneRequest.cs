#if GAMEBASE_ADD_NODECANVAS
using System;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UniRx;

namespace Gamebase.Scene.NodeCanvas.Conditions
{
    [PublicAPI]
    [Name("Check Change Scene Request")]
    [Category("✫ Gamebase/SceneManagement")]
    public sealed class CheckChangeSceneRequest : ConditionTask<SceneManagementTaskManager>
    {
        public BBParameter<string> sceneName = default;

        [BlackboardOnly] public BBParameter<object> transData = default;

        private IDisposable disposable;

        protected override string info => $"{sceneName}";

        protected override bool OnCheck()
        {
            return false;
        }
        
        protected override void OnEnable()
        {
            disposable?.Dispose();
            disposable = agent.OnChangeSignalAsObservable()
                .Where(x => x.SceneName == sceneName.value)
                .Subscribe(x =>
                {
                    transData.value = x.TransData;
                    YieldReturn(true);
                });
        }

        protected override void OnDisable()
        {
            disposable?.Dispose();
            disposable = null;
        }
    }
}
#endif