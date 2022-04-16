using Lab4.Core.ShipYard;

namespace Lab4.Core.Ship.ShipStates;

public abstract class BaseShipState
{
    protected readonly IShip Ship;

    protected BaseShipState(IShip ship)
    {
        Ship = ship;
    }

    protected void ChangeState(IShipState state, IShipYard shipYard)
    {
        Ship.State = state;
        state.DoWork(shipYard);
    }
}