// See https://aka.ms/new-console-template for more information

using PerlinNoise;
using static System.Console;
using SkiaSharp;
using System.Runtime.InteropServices.Marshalling;
using Spectre.Console;

// Selection prompt of type of noise to generate by string

Clear();
var selection = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select type of noise to generate")
        .PageSize(10)
        .AddChoices(ImageGenerator.Types)
        );
WriteLine(selection);
ImageGenerator.GenerateImage(selection);