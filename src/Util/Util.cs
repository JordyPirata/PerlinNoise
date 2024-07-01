public class Util
{
    public static float[,] GenerateFastNoiseLite(FastNoiseLite noise, int size)
    {
        float[,] noiseData = new float[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                noiseData[i, j] = noise.GetNoise(i, j) * 0.5f + 0.5f;
            }
        }
        return noiseData;
    }
}