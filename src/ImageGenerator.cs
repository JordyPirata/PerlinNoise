using static System.Console;
using SkiaSharp;

namespace PerlinNoise;

public class ImageGenerator
{
    public static double[][] GerneateRandomNoise()
    {
        
        double [][] noise = new double[512][];

        noise = RandomNoise.Generate(512, 512, 0);
        return noise;
    }
    public static double[][] GeneratePerlinNoise()
    {
        Perlin perlin = new();
        perlin.SetSeed(0);

        double [][] noise = new double[512][];
        
        double scale = 0.007;
        for (int i = 0; i < 512; i++)
        {
            noise[i] = new double[512];
            for (int j = 0; j < 512; j++)
            {
                noise[i][j] = perlin.OctavePerlin(i * scale, j * scale, 4, 0.5, 2);
            }
        }
        
        return noise;
    }
    public static void GenerateImage(string type)
    {
        //generate map x and y
        int width = 512;
        int height = 512;

        //generate map x and y values
        double[][] noise = new double[width][];
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
        SKBitmap bitmap = new SKBitmap(width, height);
        SKCanvas canvas = new SKCanvas(bitmap);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int color = (int)(noise[i][j] * 255);
                canvas.DrawPoint(i, j, new SKPaint() { Color = new SKColor((byte)color, (byte)color, (byte)color) });
            }
        }
        //save image into imgs folder
        FileStream fs = new($"imgs/{type}.png", FileMode.Create);
        WriteLine(bitmap.Encode(fs, SKEncodedImageFormat.Png, 1000));
        fs.Close();
    }
}