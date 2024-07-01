
namespace Biomes;
public class BiomeGen
{
    internal static float[,] GenerateBiomeMap(int size, int seed)
    {
        FastNoiseLite noise = new FastNoiseLite(seed);
        noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
        noise.SetFrequency(0.001f);

        float[,] noiseData = new float[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                
                noiseData[i, j] = noise.GetNoise(i, j);
            }
        }
        return noiseData;
    }
}