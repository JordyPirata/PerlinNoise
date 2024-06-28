using static System.Console;
using SkiaSharp;

namespace PerlinNoise;

public class ImageGenerator
{
    public static float[,] GerneateRandomNoise()
    {
        
        float [,] noise;

        noise = RandomNoise.Generate(1000, 1000, 0);
        return noise;
    }
    public static float[,] GeneratePerlinNoise()
    {
        FastNoiseLite noise = new FastNoiseLite();
        noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
        noise.SetFractalType(FastNoiseLite.FractalType.FBm);
        noise.SetFractalOctaves(6);
        noise.SetSeed(1337);

        // Gather noise data
        float[,] noiseData = new float[1000, 1000];

        for (int x = 0; x < 1000; x++)
        {
            for (int y = 0; y < 1000; y++)
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
                noise = GeneratePerlinNoise();
                break;
            case "RandomNoise":
                noise = GerneateRandomNoise();
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
                int grayValue = (int)(128 + 128 * noise[i,j]);
                SKColor color = new((byte)grayValue, (byte)grayValue, (byte)grayValue);
                bitmap.SetPixel(i, j, color);
            }
        }
        //save image into imgs folder
        FileStream fs = new($"imgs/{type}.png", FileMode.Create);
        WriteLine(bitmap.Encode(fs, SKEncodedImageFormat.Png, size));
        fs.Close();
    }
}