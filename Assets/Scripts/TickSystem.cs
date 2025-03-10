using System;
using UnityEngine;

public static class TickSystem 
{
    public static event Action OnTick;
    private static float tickTimer;
    private static float TICK_MAX = 1f;
    private static GameObject tickSystem;
    private class TickSystemObject :MonoBehaviour
    {
        private int tick;

        void Awake()
        {
            tick = 0;
        }
        void Update()
        {
            tickTimer = Time.deltaTime;
            if (tickTimer >= TICK_MAX)
            {
                tickTimer -= TICK_MAX;
            }
            tick++;
            OnTick?.Invoke();
        }

       
    }

    public static void Initialize()
    {
        if (tickSystem == null)
        {
            tickSystem = new GameObject("TickSystem");
            tickSystem.AddComponent<TickSystemObject>();
            UnityEngine.Object.DontDestroyOnLoad(tickSystem);
        }
    }
}
