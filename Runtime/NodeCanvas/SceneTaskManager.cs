#if GAMEBASE_ADD_NODECANVAS
using UnityEngine;
using Zenject;

namespace Gamebase.Scene.NodeCanvas
{
    public sealed class SceneTaskManager : MonoBehaviour
    {
        [Inject] internal SignalBus SignalBus { get; } = default;
    }
}
#endif