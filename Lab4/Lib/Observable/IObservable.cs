using System;

namespace Lab4.Lib.Observable;

public interface IObservable<T> : ISubscribable<T>
{
    void Emit(T next);
}