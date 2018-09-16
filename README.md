# dotnet-lib
dotnet library boilerplate

## How to run tests
```
cd .\SimpleLib.Tests\
dotnet restore
dotnet test
```

## GeoService

Simple service to request geo info by IP

### Usage
```C#
var geoService = new GeoService();
geoService.GetGeoDataByIP("134.234.3.2").Wait();
```

## Weather console

## Options

```
weather --service [serviceName] [location]

[serviceName] - weather service to use
[location] - location name somewhere on Earth
```

### Usage
```
dotnet run --service metaweather london
dotnet run --service apixu london
```

