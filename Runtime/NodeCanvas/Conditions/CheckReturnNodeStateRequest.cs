#if GAMEBASE_ADD_NODECANVAS
using System;
using Gamebase.Scene.NodeCanvas;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UniRx;

namespace Gamebase.Scene.NodeCanvas.Conditions
{
    [PublicAPI]
    [Name("Check Return Scene Request")]
    [Category("✫ Gamebase/SceneManagement")]
    public sealed class CheckReturnNodeStateRequest : ConditionTask<SceneManagementTaskManager>
    {
        private IDisposable disposable;

        protected override bool OnCheck()
        {
            return false;
        }
        
        protected override void OnEnable()
        {
            disposable?.Dispose();
            disposable = agent.OnReturnSignalAsObservable()
                .Subscribe(_ => YieldReturn(true));
        }

        protected override void OnDisable()
        {
            disposable?.Dispose();
            disposable = null;
        }
    }
}
#endif