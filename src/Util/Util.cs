using System.Drawing;

public class Util
{
    public static float[,] GenerateFastNoiseLite(FastNoiseLite noise, int size)
    {
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

    public static float[,] GenerateTemperatureMap(FastNoiseLite noise, int size)
    {
        float[,] noiseData = new float[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                noiseData[i, j] = (noise.GetNoise(i, j) - CosFunc(j, size / 2)) * 0.314159265f + .5f;

            }
        }
        return noiseData;
    }
    private static float CosFunc (float x, int size)
    {
        return (float)Math.Cos(x * 3.14159265f / size);
    }
}