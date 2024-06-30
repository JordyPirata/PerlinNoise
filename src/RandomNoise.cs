using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerlinNoise;

public static class RandomNoise
{
    public static float[,] Generate(int size, int seed)
    {
        float[,] noise = new float[size, size];
        Random random = new(seed);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                // gerenate random number between -1 and 1
                noise[i, j] = (float)random.NextDouble() * 2 - 1;
            }
        }
        return noise;
    }
}