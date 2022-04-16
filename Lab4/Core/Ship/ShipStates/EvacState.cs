using Lab4.Annotations;
using Lab4.Core.Constants;
using Lab4.Core.ShipYard;

namespace Lab4.Core.Ship.ShipStates;

public class EvacState : BaseShipState, IShipState
{
    public EvacState(IShip ship) : base(ship)
    {
    }

    public void ChangeState(IShipYard shipYard)
    {
        base.ChangeState(new RaidState(Ship), shipYard);
    }

    public void DoWork(IShipYard shipYard)
    {
        shipYard.ReleaseShip(Ship);
    }

    public void OnAlert(EWeatherType eWeatherType, IShipYard shipYard)
    {
        if (eWeatherType == EWeatherType.Good)
        {
            ChangeState(shipYard);
        }
    }

    public string Status() => ShipStatus.EvacuationBadWeather;
}