using SkiaSharp;
namespace Biomes;

public class BiomeGen
{
    public static SKBitmap GenerateBiomeMap(int size, int seed)
    {
        FastNoiseLite noise = new FastNoiseLite(seed - 1);
        noise.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
        noise.SetFractalType(FastNoiseLite.FractalType.FBm);
        noise.SetFractalOctaves(3);
        noise.SetFrequency(0.01f);

        float[,] humidityMap = Util.GenerateFastNoiseLite(noise, size);

        FastNoiseLite noise2 = new FastNoiseLite(seed + 1);
        noise2.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
        noise.SetFractalType(FastNoiseLite.FractalType.FBm);
        noise.SetFractalOctaves(3);
        noise2.SetFrequency(0.02f);

        float[,] temperatureMap = Util.GenerateFastNoiseLite(noise2, size);
        SKBitmap bitmap = new(size, size);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                SKColor color = BiomesDic.GetBiomeByValues(humidityMap[i, j], temperatureMap[i, j])?.color ?? SKColors.Black;
                bitmap.SetPixel(i, j, color);
            }
        }
        
        return bitmap;
    }
}