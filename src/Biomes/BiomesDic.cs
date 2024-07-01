using System;
using System.Collections.Generic;
using Biomes;

public class BiomesDic 
{
    private static Dictionary<Type, Biome>? Biomes;
    private static void InitializeBiomes()
    {
        Biomes = new Dictionary<Type, Biome>
        {
            // Add your biomes and their corresponding values here
            [typeof(Desert)] = new Desert(),
            [typeof(Jungle)] = new Jungle(),
            [typeof(Savanna)] = new Savanna(),
            [typeof(Taiga)] = new Taiga(),
            [typeof(Tundra)] = new Tundra()
        };
    }
    public static Biome? GetBiome(Type type)
    {
        if (Biomes == null)
        {
            InitializeBiomes();
        }
        
        return Biomes!.TryGetValue(type, out var biome)? biome : throw new Exception("Biome not found");
        
    }
    
}