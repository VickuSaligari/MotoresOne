using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private int _points;
    private readonly List<IPointsObserver> _observers = new();

    public static PointsManager Instance { get; private set; }

    public int Points
    {
        get => _points;
        set
        {
            _points = value;
            NotifyObservers(value);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterObserver(IPointsObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void UnregisterObserver(IPointsObserver observer)
    {
        if (_observers.Contains(observer))
            _observers.Remove(observer);
    }

    private void NotifyObservers(int newPoints)
    {
        foreach (var observer in _observers)
        {
            observer.OnPointsChanged(newPoints);
        }
    }
}