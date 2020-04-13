#if GAMEBASE_ADD_NODECANVAS
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.SceneManagement;

namespace Gamebase.Scene.NodeCanvas.Conditions
{
    [PublicAPI]
    [Name("Check Scene Loaded")]
    [Category("✫ Gamebase/SceneManagement")]
    public sealed class CheckSceneLoaded : ConditionTask
    {
        public BBParameter<string> sceneName = default;

        protected override string info => $"Check {sceneName} scene is loaded.";

        protected override bool OnCheck()
        {
            var scene = SceneManager.GetSceneByName(sceneName.value);
            return scene.IsValid() && scene.isLoaded;
        }
    }
}
#endif