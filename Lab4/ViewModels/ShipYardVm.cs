using Lab4.Core.Constants;
using Lab4.Core.ShipYard;

namespace Lab4.ViewModels;

public class ShipYardVm
{
    public IShipYard WaterShipYard { get; } = new ShipYard(ELoadType.Water);
    public IShipYard GasShipYard { get; } = new ShipYard(ELoadType.Gas);
    public IShipYard OilShipYard { get; } = new ShipYard(ELoadType.Oil);
    private IShipYard? _chain;
    
    public IShipYard GetChain() => _chain ??= WaterShipYard.AddNext(GasShipYard).AddNext(OilShipYard);
    

}