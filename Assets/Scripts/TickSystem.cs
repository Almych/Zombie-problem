using System;
using UnityEngine;

public static class UpdateSystem 
{
    public static event Action OnUpdate;
    private static GameObject tickSystem;

   
    private class UpdateSystemObject : MonoBehaviour
    {
        private bool isPaused;

        private void Awake()
        {
            EventBus.Subscribe<OnPauseEvent>(PauseTick);
        }
        private void Update()
        {
            if (isPaused)
                return;
            OnUpdate?.Invoke();
        }

        private void OnDestroy()
        {
            EventBus.UnSubscribe<OnPauseEvent>(PauseTick);
        }
        private void PauseTick(OnPauseEvent e)
        {
            isPaused = e.IsPaused;
        }
    }
    public static void Initialize()
    {
        if (tickSystem == null)
        {
            tickSystem = new GameObject("TickSystem");
            tickSystem.AddComponent<UpdateSystemObject>();
            UnityEngine.Object.DontDestroyOnLoad(tickSystem);
        }
    }
}
