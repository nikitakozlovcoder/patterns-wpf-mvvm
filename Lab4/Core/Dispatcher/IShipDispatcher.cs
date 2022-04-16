using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using Lab4.Core.Constants;
using Lab4.Core.Ship;
using Lab4.Core.Ship.ShipStates;
using Lab4.Core.ShipYard;

namespace Lab4.Core.Dispatcher;

public interface IShipDispatcher
{
    public ObservableCollection<IShip> Ships { get; }
    IShip CreateShip(string name, bool isLoaded, ELoadType eLoadType);
    void ChangeShipState(IShip ship, IShipYard shipYard);
}