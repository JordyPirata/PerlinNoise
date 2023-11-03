// See https://aka.ms/new-console-template for more information

using PerlinNoise;
using static System.Console;
using SkiaSharp;

generateImage();



static void generateImage()
{
    //generate map x and y
    int width = 512;
    int height = 512;

    //generate map x and y 
    double[][] noise = RandomNoise.Generate(width, height, 0);

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
    //save image
    FileStream fs = new FileStream("noise.png", FileMode.Create);
    WriteLine(bitmap.Encode(fs, SKEncodedImageFormat.Png, 1000));
    fs.Close();
}