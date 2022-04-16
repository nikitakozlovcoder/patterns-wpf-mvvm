using System;
using Lab4.Core.Constants;
using Lab4.Lib.Observable;

namespace Lab4.Core.Meteo;

public class Meteo : IMeteo
{
    private EWeatherType _currentEWeather = EWeatherType.Good;
    private readonly BehaviourSubject<EWeatherType> _weatherNotifier;
    public ISubscribable<EWeatherType> WeatherNotifier => _weatherNotifier;
    
    public Meteo()
    {
        _weatherNotifier = new BehaviourSubject<EWeatherType>(_currentEWeather);
    }
    
    public void NotifyWeatherChange()
    {
        _currentEWeather = _currentEWeather == EWeatherType.Good ? EWeatherType.Bad : EWeatherType.Good;
        _weatherNotifier.Emit(_currentEWeather);
    }
}