using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType 
{
    OnPlayerDamage,
    OnEnemyDamage,
    OnHealth,
    OnReload,
    OnPickUp,
    OnUpdateInventory
}

public static class EventManager
{
    public delegate void EventReceiver(params object[] parameter);

    static Dictionary<EventType, EventReceiver> _events = new Dictionary<EventType, EventReceiver>();

    public static void Subscribe(EventType eventType, EventReceiver method)
    {
        if (!_events.ContainsKey(eventType))
            _events.Add(eventType, method);
        else
            _events[eventType] += method;
    }

    public static void UnSubscribe(EventType eventType, EventReceiver method)
    {
        if (_events.ContainsKey(eventType))
        {
            _events[eventType] -= method;

            if (_events[eventType] == null)
                _events.Remove(eventType);
        }
    }

    public static void Trigger(EventType eventType, params object[] parameters)
    {
        if (_events.ContainsKey(eventType))
            _events[eventType](parameters);
    }

    public static void ResetEventDictionary()
    {
        _events = new Dictionary<EventType, EventReceiver>();
    }
}