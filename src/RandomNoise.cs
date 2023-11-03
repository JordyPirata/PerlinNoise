using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerlinNoise;

public class RandomNoise
{
    public static double[][] Generate(int x, int y, int seed)
    {
        Random random = new Random(seed);
        double[][] noise = new double[x][];
        for (int i = 0; i < x; i++)
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