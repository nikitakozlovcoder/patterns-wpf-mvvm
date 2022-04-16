using Lab4.Core.Constants;
using Lab4.Lib.Observable;

namespace Lab4.Core.Meteo;

public interface IMeteo
{
    ISubscribable<EWeatherType> WeatherNotifier { get; }
    void NotifyWeatherChange();
}