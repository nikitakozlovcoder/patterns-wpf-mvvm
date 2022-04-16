using System;

namespace Lab4.Lib.Observable;

public interface ISubscribable<T>
{
    Unsubscriber<T> Subscribe(Action<T> callback);
}