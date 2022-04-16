using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lab4.Annotations;
using Lab4.Core.Constants;

namespace Lab4.ViewModels;

public class NewShipRequest : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
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

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Reset()
    {
        Name = string.Empty;
        IsLoaded = false;
        ELoadType = ELoadType.Water;
    }
}