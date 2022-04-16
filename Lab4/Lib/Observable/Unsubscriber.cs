using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Lab4.Lib.Observable;

public class Unsubscriber<T> : IDisposable
{
    private readonly List<Action<T>> _subscribers;
    private readonly Action<T> _action;

    public Unsubscriber(List<Action<T>> subscribers, Action<T> action)
    {
        _subscribers = subscribers;
        _action = action;
    }
    
    public void Dispose()
    {
        _subscribers.RemoveAll(x => x == _action);
    }
}