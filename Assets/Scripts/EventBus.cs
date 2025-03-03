using System;
using System.Linq;
using System.Collections.Generic;

public static class EventBus 
{
    private static Dictionary<Type, List<EventBusListener>> eventListeners = new Dictionary<Type, List<EventBusListener>>();
    public static void Subscribe<T>(Action<T> action, int priority=0) where T: class
    {
        Type eventType = typeof(T);
        if (!eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType] = new List<EventBusListener>();
        }
        eventListeners[eventType].Add(new EventBusListener(action, priority));

        eventListeners[eventType] = eventListeners[eventType].OrderBy(e => e._priority).ToList();
    }

    public static void UnSubscribe<T>(Action<T> action) where T: class
    {
        Type eventType = typeof(T);
        if (eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType].RemoveAll(e => e._callBackEvent.Equals(action));
        }
    }


    public static void Publish<T>(T eventData)
    {
        Type eventType = typeof(T);
        if (eventListeners.ContainsKey(eventType))
        {
            foreach (var listener in eventListeners[eventType])
            {
                listener._callBackEvent.DynamicInvoke(eventData);
            }
        }
    }
}

public class EventBusListener
{
    public Delegate _callBackEvent { get; }
    public int _priority { get; }
    public EventBusListener(Delegate @delegate, int priority)
    {
        _callBackEvent = @delegate;
        _priority = priority;
    }
}
