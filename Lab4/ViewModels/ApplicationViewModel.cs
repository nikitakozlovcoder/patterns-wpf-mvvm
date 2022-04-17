using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using System.Windows.Threading;
using Lab4.Annotations;
using Lab4.Core.Constants;
using Lab4.Core.Dispatcher;
using Lab4.Core.Meteo;
using Lab4.Core.Ship;
using Lab4.Core.Ship.ShipFactory;
using Lab4.Core.ShipYard;
using Lab4.Lib.Command;

namespace Lab4.ViewModels;

public sealed class ApplicationViewModel : INotifyPropertyChanged
{
    private readonly IShipYard _shipYard;
    private readonly IMeteo _meteo = new Meteo();
    public ShipYardVm ShipYardVm { get; } = new ();
    public IShipDispatcher ShipDispatcher { get; }
    private IShip? _selectedShip;
    private EWeatherType? _weatherType;

    public EWeatherType? WeatherType
    {
        get => _weatherType;
        set
        {
            _weatherType = value;
            OnPropertyChanged(nameof(WeatherType));
        }
    }

    public IShip? SelectedShip
    {
        get => _selectedShip;
        set
        {
            _selectedShip = value;
            OnPropertyChanged(nameof(SelectedShip));
        }
    }

    public NewShipRequest NewShipRequest { get; } = new ();
    public BasicCommand AddShipCommand => new(
        _ =>
        {
            ShipDispatcher.CreateShip(NewShipRequest.Name, NewShipRequest.IsLoaded, NewShipRequest.ELoadType);
            NewShipRequest.Reset();
        }, 
        _ => !string.IsNullOrWhiteSpace(NewShipRequest.Name));
    
    public BasicCommand NotifyChangeWeather => new(
        _ =>
        {
            _meteo.NotifyWeatherChange();
        });
    
    public BasicCommand ChangeShipState => new(
        _ =>
        {
            if (_selectedShip == null)
            {
                return;
            }
            ShipDispatcher.ChangeShipState(_selectedShip, _shipYard);
        }, _ => _weatherType == EWeatherType.Good && _selectedShip != null && _shipYard.CheckCanProcessShip(_selectedShip));
    
    public ApplicationViewModel()
    {
        _shipYard = ShipYardVm.GetChain();
        ShipDispatcher = new ShipDispatcher(new ShipFactory(), _meteo.WeatherNotifier, _shipYard);
        ShipDispatcher.CreateShip("ship 1", true, ELoadType.Gas);
        ShipDispatcher.CreateShip("ship 2", false, ELoadType.Water);
        SelectedShip = ShipDispatcher.CreateShip("ship 3", false, ELoadType.Water);
        _meteo.WeatherNotifier.Subscribe(x => WeatherType = x);

    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}