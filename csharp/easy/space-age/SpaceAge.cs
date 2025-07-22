using System;

public class SpaceAge(int seconds)
{
    private const double SECONDS_IN_EARTH_YEAR = 365.25 /*days*/ * 24 /*hours*/ * 60 /*minutes*/ * 60 /*seconds*/;

    private const double MERCURY_ORBITAL_PERIOD_TO_EARTH_RATIO = 0.2408467;
    private const double VENUS_ORBITAL_PERIOD_TO_EARTH_RATIO = 0.61519726;
    private const double MARS_ORBITAL_PERIOD_TO_EARTH_RATIO = 1.8808158;
    private const double JUPITER_ORBITAL_PERIOD_TO_EARTH_RATIO = 11.862615;
    private const double SATURN_ORBITAL_PERIOD_TO_EARTH_RATIO = 29.447498;
    private const double URANUS_ORBITAL_PERIOD_TO_EARTH_RATIO = 84.016846;
    private const double NEPTUNE_ORBITAL_PERIOD_TO_EARTH_RATIO = 164.79132;

    public double OnEarth() => seconds / SpaceAge.SECONDS_IN_EARTH_YEAR;

    public double OnMercury() => OnEarth() / SpaceAge.MERCURY_ORBITAL_PERIOD_TO_EARTH_RATIO;

    public double OnVenus() => OnEarth() / SpaceAge.VENUS_ORBITAL_PERIOD_TO_EARTH_RATIO;

    public double OnMars() => OnEarth() / SpaceAge.MARS_ORBITAL_PERIOD_TO_EARTH_RATIO;

    public double OnJupiter() => OnEarth() / SpaceAge.JUPITER_ORBITAL_PERIOD_TO_EARTH_RATIO;

    public double OnSaturn() => OnEarth() / SpaceAge.SATURN_ORBITAL_PERIOD_TO_EARTH_RATIO;

    public double OnUranus() => OnEarth() / SpaceAge.URANUS_ORBITAL_PERIOD_TO_EARTH_RATIO;

    public double OnNeptune() => OnEarth() / SpaceAge.NEPTUNE_ORBITAL_PERIOD_TO_EARTH_RATIO;
}