using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerlinNoise;

public static class RandomNoise
{
    public static float[,] Generate(int width, int y, int seed)
    {
        float[,] noise = new float[width, y];
        Random random = new(seed);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < y; j++)
            {
                noise[i, j] = (float)random.NextDouble();
            }
        }
        return noise;
    }
}