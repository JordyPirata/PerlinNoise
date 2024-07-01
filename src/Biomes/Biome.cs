using SkiaSharp;

namespace Biomes;

public abstract class Biome
{
    public float2 temperatureRange;
    public float2 humidityRange;
    public SKColor color;
}
public class Tundra : Biome {}
public class Taiga : Biome {}
public class Savanna : Biome {}
public class Jungle : Biome {}
public class Desert : Biome {}