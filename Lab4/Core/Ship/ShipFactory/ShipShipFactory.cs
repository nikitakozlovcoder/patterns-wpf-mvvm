using Lab4.Core.Constants;

namespace Lab4.Core.Ship.ShipFactory;

public class ShipFactory : BaseShipFactory
{
    public override IShip Create(string name, bool isLoaded, ELoadType eLoadType)
    {
        return new Ship
        {
            Name = name,
            IsLoaded = isLoaded,
            ELoadType = eLoadType
        };
    }
}