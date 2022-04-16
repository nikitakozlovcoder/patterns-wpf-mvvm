using Lab4.Core.Constants;

namespace Lab4.Core.Ship.ShipFactory;

public abstract class BaseShipFactory
{
    public abstract IShip Create(string name, bool isLoaded, ELoadType eLoadType);
}