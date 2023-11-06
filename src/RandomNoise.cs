using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerlinNoise;

public static class RandomNoise
{
    public static double[][] Generate(int width, int y, int seed)
    {
        Random random = new Random(seed);
        double[][] noise = new double[width][];
        for (int i = 0; i < width; i++)
        {
            noise[i] = new double[y];
            for (int j = 0; j < y; j++)
            {
                noise[i][j] = random.NextDouble();
            }
        }
        return noise;
    }
}