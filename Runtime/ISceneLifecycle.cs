using UniRx.Async;

namespace Gamebase.Scene
{
    public interface ISceneLifecycle
    {
        UniTask OnInitialize(object transData);
        
        UniTask OnFadeIn();
        
        UniTask OnFadeOut();
        
        void OnDispose();
    }
}