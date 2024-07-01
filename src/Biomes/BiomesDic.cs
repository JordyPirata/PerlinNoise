using System;
using System.Collections.Generic;
using Biomes;
using SkiaSharp;

public class BiomesDic 
{
    private static Dictionary<Type, Biome>? Biomes;
    private static void InitializeBiomes()
    {
        Biomes = new Dictionary<Type, Biome>
        {
            // Add your biomes and their corresponding values here
            [typeof(Tundra)] = new Tundra()
            {
                humidityRange = new float2(0, 1),
                temperatureRange = new float2(0.0f, 0.2f),
                color = new SKColor(212, 219, 206) // #d4dbce light grey
            },
            [typeof(Taiga)] = new Taiga()
            {
                humidityRange = new float2(0, 0.25f),
                temperatureRange = new float2(0.2f, 0.4f),
                color = new SKColor(63, 133, 13) // #3f850d dark green
            },
            [typeof(Desert)] = new Desert()
            {
                humidityRange = new float2(0.0f, 0.1f),
                temperatureRange = new float2(0.2f, 1),
                color = new SKColor(204, 204, 135) // #cccc87 sand
            },
            [typeof(Jungle)] = new Jungle()
            {
                humidityRange = new float2(0.625f, 1f),
                temperatureRange = new float2(0.7f, 1.0f),
                color = new SKColor(0, 100, 0) // #006400 dark green
            },
            [typeof(Savanna)] = new Savanna()
            {
                humidityRange = new float2(0.25f, 0.625f),
                temperatureRange = new float2(0.7f, 1.0f),
                color = new SKColor(218, 165, 32) // #daa520 gold
            },
            
            
        };
    }
    public static Biome? GetBiome(Type type)
    {
        if (Biomes == null)
        {
            InitializeBiomes();
        }
        
        return Biomes!.TryGetValue(type, out var biome)? biome : null;
        
    }
    public static Biome? GetBiomeByValues(float humidity, float temperature)
    {
        if (Biomes == null)
        {
            InitializeBiomes();
        }
        foreach (var biome in Biomes!.Values)
        {
            if (humidity >= biome.humidityRange.x && humidity <= biome.humidityRange.y &&
                temperature >= biome.temperatureRange.x && temperature <= biome.temperatureRange.y)
            {
                return biome;
            }
        }
        return null;
    }
    
}