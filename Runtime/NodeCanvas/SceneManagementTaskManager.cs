#if GAMEBASE_ADD_NODECANVAS
using System;
using Gamebase.Scene.NodeCanvas.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gamebase.Scene.NodeCanvas
{
    public sealed class SceneManagementTaskManager : MonoBehaviour
    {
        [Inject] private SignalBus signalBus = default;
        
        [Inject] internal ISceneController Controller { get; } = default;
        
        private readonly ISubject<ChangeSceneSignal> onChange = new Subject<ChangeSceneSignal>();
        
        private readonly ISubject<NextSceneSignal> onNext = new Subject<NextSceneSignal>();

        private readonly ISubject<ReturnSceneSignal> onReturn = new Subject<ReturnSceneSignal>();

        private void Start()
        {
            signalBus.Subscribe<ChangeSceneSignal>(x => onChange.OnNext(x));
            signalBus.Subscribe<NextSceneSignal>(x => onNext.OnNext(x));
            signalBus.Subscribe<ReturnSceneSignal>(x => onReturn.OnNext(x));
            
        }
        
        internal IObservable<ChangeSceneSignal> OnChangeSignalAsObservable()
        {
            return onChange;
        }
        
        internal IObservable<NextSceneSignal> OnNextSignalAsObservable()
        {
            return onNext;
        }
        
        internal IObservable<ReturnSceneSignal> OnReturnSignalAsObservable()
        {
            return onReturn;
        }
    }
}
#endif