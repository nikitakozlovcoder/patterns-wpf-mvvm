using System;
using Lab4.Core.Constants;
using Lab4.Core.Ship;
using Lab4.Core.Ship.ShipStates;

namespace Lab4.Core.ShipYard;

public class ShipYard : IShipYard
{
    private IShipYard? _next;
    private readonly ELoadType _acceptedELoadType;
    public IShip? CurrentShip { get; set; }
    
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
}