using System;
using UnityEngine;

public static class UpdateSystem 
{
    public static event Action OnUpdate;
    public static event Action OnLateUpdate;
    public static event Action CallUpdate;
    private static GameObject tickSystem;
    private const float updateTick = .1f;
    private const float lateTick = 0.75f;
   
    private class UpdateSystemObject : MonoBehaviour
    {
        private bool isPaused;
        private float tickUpdateTimer;
        private float tickLateUpdate;

        private void Awake()
        {
            EventBus.Subscribe<OnPauseEvent>(PauseTick);
        }
        private void Update()
        {
            if (isPaused)
                return;

            tickUpdateTimer += Time.deltaTime;
            tickLateUpdate += Time.deltaTime;


            if (tickUpdateTimer >= updateTick)
            {
                tickUpdateTimer = 0;
                OnUpdate?.Invoke();
            }

            if (tickLateUpdate >= lateTick)
            {
                tickLateUpdate = 0;
                OnLateUpdate?.Invoke();
            }
            CallUpdate?.Invoke();
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
