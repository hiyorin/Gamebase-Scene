using UniRx.Async;
using UnityEngine;

namespace Gamebase.Scene.Samples.Lifecycle
{
    public sealed class SceneLifecycleSample : MonoBehaviour, ISceneLifecycle
    {
        #region ISceneLifecycle implementation
        
        public async UniTask OnInitialize(object transData)
        {
            Debug.unityLogger.Log(GetType().Name, "OnInitialize");
        }

        public async UniTask OnFadeIn()
        {
            Debug.unityLogger.Log(GetType().Name, "OnFadeIn");
        }

        public async UniTask OnFadeOut()
        {
            Debug.unityLogger.Log(GetType().Name, "OnFadeOut");
        }

        public void OnDispose()
        {
            Debug.unityLogger.Log(GetType().Name, "OnDispose");
        }
        
        #endregion
    }
}