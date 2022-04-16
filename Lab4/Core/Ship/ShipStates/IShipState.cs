using Lab4.Core.Constants;
using Lab4.Core.ShipYard;

namespace Lab4.Core.Ship.ShipStates;

public interface IShipState
{
    void ChangeState(IShipYard shipYard);
    void DoWork(IShipYard shipYard);
    void OnAlert(EWeatherType eWeatherType, IShipYard shipYard);
    string Status();
}