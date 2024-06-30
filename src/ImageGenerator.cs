using static System.Console;
using SkiaSharp;

namespace PerlinNoise;

public class ImageGenerator
{
    private const string 
        perlinNoise = "PerlinNoise", randomNoise = "RandomNoise", 
        fractalNoise = "FractalNoise", worleyNoise = "WorleyNoise";
    public static string[] Types { get; } = [perlinNoise, randomNoise, fractalNoise, worleyNoise];
    public static void GenerateImage(string type)
    {
        int size = 1000;

        //generate map x and y values
        float[,] noise = new float[size,size];
        switch (type)
        {
            
            case perlinNoise:
                FastNoiseLite perlinState = new(); 
                perlinState.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
                perlinState.SetSeed(1);
                noise = GenerateFastNoiseLite(perlinState, size);
                break;
            case randomNoise:
                noise = RandomNoise.Generate(size, 2);
                break;
            case fractalNoise:
                FastNoiseLite fractalState = new();
                fractalState.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
                fractalState.SetSeed(1);
                fractalState.SetFractalType(FastNoiseLite.FractalType.FBm);
                fractalState.SetFractalOctaves(3);
                fractalState.SetFrequency(0.01f);
                noise = GenerateFastNoiseLite(fractalState, size);
                break;
            case worleyNoise:
                FastNoiseLite worleyState = new();
                worleyState.SetNoiseType(FastNoiseLite.NoiseType.Cellular);
                worleyState.SetCellularDistanceFunction(FastNoiseLite.CellularDistanceFunction.Euclidean);
                worleyState.SetCellularReturnType(FastNoiseLite.CellularReturnType.Distance2);
                noise = GenerateFastNoiseLite(worleyState, size);
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
                byte saturateValue = (byte)(128 + 128 * noise[i, j]),
                    redValue = saturateValue,
                    greenValue = saturateValue,
                    blueValue = saturateValue;
                SKColor color = new(redValue, greenValue, blueValue);
                bitmap.SetPixel(i, j, color);

            }
        }
        //save image into imgs folder
        FileStream fs = new($"imgs/{type}.png", FileMode.Create);
        WriteLine(bitmap.Encode(fs, SKEncodedImageFormat.Png, size));
        fs.Close();
    }
    private static float[,] GenerateFastNoiseLite(FastNoiseLite state, int size)
    {
        // Gather noise data
        float[,] noiseData = new float[size, size];

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                noiseData[x, y] = state.GetNoise(x, y);
            }
        }
        return noiseData;
    }
}