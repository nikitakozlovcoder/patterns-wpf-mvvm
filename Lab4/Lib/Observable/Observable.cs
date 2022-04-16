using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Lab4.Lib.Observable;

public class Observable<T> : IObservable<T>
{
    private readonly List<Action<T>> _callbackList = new  ();
    public Unsubscriber<T> Subscribe(Action<T> callback)
    {
        _callbackList.Add(callback);
       return new Unsubscriber<T>(_callbackList, callback);
    }

    public void Emit(T next)
    {
        foreach (var callback in _callbackList)
        {
            callback(next);
        }
    }
}