using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lab4.Annotations;
using Lab4.Core.Constants;
using Lab4.Core.Ship;
using Lab4.Core.Ship.ShipStates;

namespace Lab4.Core.ShipYard;

public class ShipYard : IShipYard, INotifyPropertyChanged
{
    private IShipYard? _next;
    private readonly ELoadType _acceptedELoadType;
    private IShip? _currentShip;

    public IShip? CurrentShip
    {
        get => _currentShip;
        private set
        {
            _currentShip = value;
            OnPropertyChanged(nameof(CurrentShip));
        }
    }

    public ShipYard(ELoadType acceptedELoadType)
    {
       _acceptedELoadType = acceptedELoadType;
    }
    
    public bool ProcessShip(IShip ship)
    {
        if (ship.ELoadType != _acceptedELoadType || CurrentShip != null) 
            return _next?.ProcessShip(ship) ?? false;
        
        CurrentShip = ship;
        CurrentShip.IsLoaded = !CurrentShip.IsLoaded;
        return true;
    }

    public IShipYard AddNext(IShipYard shipYard)
    {
        if (_next != null)
        {
            _next.AddNext(shipYard);
        }
        else
        {
            _next = shipYard;
        }
        
        return this;
    }

    public bool CheckCanProcessShip(IShip ship)
    {
        if (CurrentShip == ship)
            return true;
        
        if (ship.ELoadType != _acceptedELoadType || CurrentShip != null) 
            return _next?.CheckCanProcessShip(ship) ?? false;
        
        return true;
    }

    public void ReleaseShip(IShip ship)
    {
        if (CurrentShip == ship)
        {
            CurrentShip = default;
        }

        _next?.ReleaseShip(ship);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}