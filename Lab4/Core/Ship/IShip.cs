using Lab4.Core.Constants;
using Lab4.Core.Ship.ShipStates;

namespace Lab4.Core.Ship;

public interface IShip
{
    public IShipState State { get; set; }
    string Name { get; set; }
    bool IsLoaded { get; set; }
    ELoadType ELoadType { get; set; }
    public string Status { get; }
    bool CanBeDeleted { get; }
}