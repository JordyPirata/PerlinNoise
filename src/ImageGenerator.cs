using static System.Console;
using SkiaSharp;

namespace PerlinNoise;

public class ImageGenerator
{
    public static float[,] GerneateRandomNoise(int size, int seed)
    {
        
        float [,] noise;

        noise = RandomNoise.Generate(size, size, seed);
        return noise;
    }
    public static float[,] GeneratePerlinNoise(int size, int seed)
    {
        FastNoiseLite noise = new();
        noise.SetNoiseType(FastNoiseLite.NoiseType.Cellular);
        noise.SetFractalType(FastNoiseLite.FractalType.FBm);
        noise.SetFractalOctaves(6);
        noise.SetFrequency(0.008f);
        noise.SetSeed(seed);

        // Gather noise data
        float[,] noiseData = new float[size, size];

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                noiseData[x, y] = noise.GetNoise(x, y);
            }
        }
                
        return noiseData;
    }
    
    public static void GenerateImage(string type)
    {
        int size = 1000;

        //generate map x and y values
        float[,] noise = new float[size,size];
        switch (type)
        {
            case "PerlinNoise":
                noise = GeneratePerlinNoise(size, 2);
                break;
            case "RandomNoise":
                noise = GerneateRandomNoise(size, 2);
                break;
            default:
                break;
        }
        
        //visualize map on black and white pixels
        SKBitmap bitmap = new(size, size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                byte redValue = (byte)(210 + 128 * noise[i, j]);
                byte greenValue = (byte)(128 + 128 * noise[i, j]);
                byte blueValue = (byte)(128 + 128 * noise[i, j]);
                SKColor color = new(redValue, 240, 240, 250);
                bitmap.SetPixel(i, j, color);

            }
        }
        //save image into imgs folder
        FileStream fs = new($"imgs/{type}.png", FileMode.Create);
        WriteLine(bitmap.Encode(fs, SKEncodedImageFormat.Png, size));
        fs.Close();
    }
}