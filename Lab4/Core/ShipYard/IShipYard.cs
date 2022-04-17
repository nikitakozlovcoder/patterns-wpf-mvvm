using Lab4.Core.Ship;

namespace Lab4.Core.ShipYard;

public interface IShipYard
{
    IShip? CurrentShip { get; }
    bool ProcessShip(IShip ship);
    IShipYard AddNext(IShipYard shipYard);
    bool CheckCanProcessShip(IShip ship);
    void ReleaseShip(IShip ship);
}