using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lab4.Core.Constants;
using Lab4.Core.Ship;
using Lab4.Core.Ship.ShipFactory;
using Lab4.Core.Ship.ShipStates;
using Lab4.Core.ShipYard;
using Lab4.Lib.Observable;

namespace Lab4.Core.Dispatcher;

public class ShipDispatcher : IShipDispatcher
{
    private readonly BaseShipFactory _shipFactory;
    public ObservableCollection<IShip> Ships { get; } = new ();
    public ShipDispatcher(BaseShipFactory shipFactory, ISubscribable<EWeatherType> meteoWeatherNotifier, IShipYard shipYard)
    {
        _shipFactory = shipFactory;
        meteoWeatherNotifier.Subscribe(x =>
        {
            foreach (var ship in Ships)
            {
                ship.State.OnAlert(x, shipYard);
            }
        });
    }
    
    public IShip CreateShip(string name, bool isLoaded, ELoadType eLoadType)
    {
        var ship = _shipFactory.Create(name, isLoaded, eLoadType);
        Ships.Insert(0, ship);
        return ship; 
    }

    public void ChangeShipState(IShip ship, IShipYard shipYard)
    {
        ship.State.ChangeState(shipYard);
    }
}