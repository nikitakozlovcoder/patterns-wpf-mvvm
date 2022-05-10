using Lab4.Core.Constants;
using Lab4.Core.ShipYard;

namespace Lab4.Core.Ship.ShipStates;

public class YardState : BaseShipState, IShipState
{
    public YardState(IShip ship) : base(ship)
    {
    }

    public void ChangeState(IShipYard shipYard)
    {
       base.ChangeState(new RaidState(Ship), shipYard);
    }

    public void DoWork(IShipYard shipYard)
    {
        var isSuccess = shipYard.ProcessShip(Ship);
        if (!isSuccess)
        {
            ChangeState(shipYard);
        }
    }

    public void OnAlert(EWeatherType eWeatherType, IShipYard shipYard)
    {
        if (eWeatherType == EWeatherType.Bad)
        {
            base.ChangeState(new EvacState(Ship), shipYard);
        }
    }

    public string Status() => ShipStatus.OnYard;
    public bool CanShipBeDeleted => false;
}