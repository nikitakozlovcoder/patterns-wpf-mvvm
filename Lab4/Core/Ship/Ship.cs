using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lab4.Annotations;
using Lab4.Core.Constants;
using Lab4.Core.Ship.ShipStates;

namespace Lab4.Core.Ship;

public class Ship : IShip, INotifyPropertyChanged
{
    private IShipState _state = null!;

    public IShipState State
    {
        get => _state;

        set
        {
            _state = value;
            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(State));
        }
    }

    private string _name = "";
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    
    private bool _isLoaded;
    public bool IsLoaded
    {
        get => _isLoaded;
        set
        {
            _isLoaded = value;
            OnPropertyChanged(nameof(IsLoaded));
        }
    }
    
    private ELoadType _eLoadType;
    public ELoadType ELoadType
    {
        get => _eLoadType;
        set
        {
            _eLoadType = value;
            OnPropertyChanged(nameof(ELoadType));
        }
    }

    public string Status => State.Status();
    public bool CanBeDeleted => State.CanShipBeDeleted;

    public Ship()
    {
        State = new RaidState(this);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}