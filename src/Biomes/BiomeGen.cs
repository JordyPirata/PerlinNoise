using SkiaSharp;
namespace Biomes;

public class BiomeGen
{
    public static SKBitmap GenerateBiomeImage(int size, int seed)
    {
        FastNoiseLite noise = new(seed - 1);
        noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2S);
        noise.SetFractalType(FastNoiseLite.FractalType.FBm);
        noise.SetFractalOctaves(6);
        noise.SetFrequency(0.01f);

        float[,] humidityMap = Util.GenerateFastNoiseLite(noise, size);

        FastNoiseLite noise2 = new(seed + 1);
        noise2.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
        noise2.SetFractalType(FastNoiseLite.FractalType.FBm);
        noise2.SetFractalOctaves(6);
        noise2.SetFrequency(0.01f);

        float[,] temperatureMap = Util.GenerateTemperatureMap(noise2, size);
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