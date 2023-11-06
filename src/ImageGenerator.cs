using static System.Console;
using SkiaSharp;

namespace PerlinNoise;

public class ImageGenerator
{
    public static double[][] GerneateRandomNoise()
    {
        
        double [][] noise;

        noise = RandomNoise.Generate(1000, 1000, 0);
        return noise;
    }
    public static double[][] GeneratePerlinNoise()
    {
        Perlin perlin = new();
        perlin.SetSeed(0);
        int size = 1000;

        double [][] noise = new double[size][];
        
        double scale = 0.07;
        for (int i = 0; i < size; i++)
        {
            noise[i] = new double[size];
            for (int j = 0; j < size; j++)
            {
                noise[i][j] = perlin.CalculatePerlin(i * scale, j * scale);

                // Normalize noise value to [-1, 1]
                noise[i][j] /= 1.5;
            }
        }
        
        return noise;
    }
    private static double[][] GenerateFractalNoise()
    {
        Perlin perlin = new();
        perlin.SetSeed(1);
        int size = 1000;

        double [][] noise = new double[size][];
        
        double scale = 0.007;
        for (int i = 0; i < size; i++)
        {
            noise[i] = new double[size];
            for (int j = 0; j < size; j++)
            {
                noise[i][j] = perlin.OctavePerlin(i * scale, j * scale, 9, 0.5, 2);
                // Normalize noise value to [-1, 1] 
                noise[i][j] /= 1.5;
            }
        }
        
        return noise;
    }
    public static void GenerateImage(string type)
    {
        int size = 1000;

        //generate map x and y values
        double[][] noise = new double[size][];
        switch (type)
        {
            case "PerlinNoise":
                noise = GeneratePerlinNoise();
                break;
            case "RandomNoise":
                noise = GerneateRandomNoise();
                break;
            case "FractalNoise":
                noise = GenerateFractalNoise();
                break;
            default:
                break;
        }
        
        //visualize map on black and white pixels
        SKBitmap bitmap = new SKBitmap(size, size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                int grayValue = (int)(128 + 128 * noise[i][j]);
                SKColor color = new SKColor((byte)grayValue, (byte)grayValue, (byte)grayValue);
                bitmap.SetPixel(i, j, color);
            }
        }
        //save image into imgs folder
        FileStream fs = new($"imgs/{type}.png", FileMode.Create);
        WriteLine(bitmap.Encode(fs, SKEncodedImageFormat.Png, size));
        fs.Close();
    }
}