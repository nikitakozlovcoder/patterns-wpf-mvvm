using System;
using System.Collections.Generic;

namespace Lab4.Lib.Observable;

public class BehaviourSubject<T> : IObservable<T>
{
    private readonly List<Action<T>> _callbackList = new  ();
    private T _lastValue;

    public BehaviourSubject(T lastValue)
    {
        _lastValue = lastValue;
    }

    public Unsubscriber<T> Subscribe(Action<T> callback)
    {
        _callbackList.Add(callback);
        if (_lastValue != null) 
            callback(_lastValue);

        return new Unsubscriber<T>(_callbackList, callback);
    }

    public void Emit(T next)
    {
        _lastValue = next;
        foreach (var callback in _callbackList)
        {
            callback(next);
        }
    }
}