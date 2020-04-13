#if GAMEBASE_ADD_NODECANVAS

namespace Gamebase.Scene.NodeCanvas.Signals
{
    public sealed class ChangeSceneSignal
    {
        public readonly string SceneName;

        public readonly object TransData;
        
        public ChangeSceneSignal(string sceneName, object transData)
        {
            SceneName = sceneName;
            TransData = transData;
        }
    }
}
#endif