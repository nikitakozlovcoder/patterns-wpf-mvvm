using Lab4.Core.Constants;
using Lab4.Core.ShipYard;

namespace Lab4.Core.Ship.ShipStates;

public class RaidState : BaseShipState, IShipState
{
   
    public RaidState(IShip ship) : base(ship)
    {
    }
    
    public void ChangeState(IShipYard shipYard)
    {
        base.ChangeState(new YardState(Ship), shipYard);
    }

    public void DoWork(IShipYard shipYard)
    {
        shipYard.ReleaseShip(Ship);
    }

    public void OnAlert(EWeatherType eWeatherType, IShipYard shipYard)
    {
        if (eWeatherType == EWeatherType.Bad)
        {
            base.ChangeState(new EvacState(Ship), shipYard);
        }
    }

    public string Status() => ShipStatus.InRaid;
}