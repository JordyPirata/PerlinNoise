using PerlinNoise;

public class PerlinTests
{
    [Fact]
    public void Permutation_ShouldReturnByteArrayWithLength512()
    {
        // Arrange
        var perlin = new Perlin();

        // Act
        var result = perlin.Permutation();

        // Assert
        Assert.Equal(512, result.Length);
    }

    [Fact]
    public void Permutation_ShouldReturnDifferentByteArraysForDifferentSeeds()
    {
        // Arrange
        var perlin1 = new Perlin();
        perlin1.SetSeed(1);
        var perlin2 = new Perlin();
        perlin2.SetSeed(2);

        // Act
        var result1 = perlin1.Permutation();
        var result2 = perlin2.Permutation();

        // Assert
        Assert.NotEqual(result1, result2);
    }

    [Fact]
    public void Permutation_ShouldReturnSameByteArrayForSameSeed()
    {
        // Arrange
        var perlin1 = new Perlin();
        var perlin2 = new Perlin();

        // Act
        var result1 = perlin1.Permutation();
        var result2 = perlin2.Permutation();

        // Assert
        Assert.Equal(result1, result2);
    }

    [Fact]
    public void CalculatePerlin_ShouldReturnDifferentValuesForDifferentInputs()
    {
        // Arrange
        var perlin = new Perlin();
        perlin.SetSeed(1);

        // Act
        var result1 = perlin.CalculatePerlin(0.5, 0.5);
        var result2 = perlin.CalculatePerlin(0.6, 0.6);

        // Assert
        Assert.NotEqual(result1, result2);
    }

    [Fact]
    public void CalculatePerlin_ShouldReturnSameValueForSameInputs()
    {
        // Arrange
        var perlin1 = new Perlin();
        perlin1.SetSeed(1);
        var perlin2 = new Perlin();
        perlin2.SetSeed(1);

        // Act
        var result1 = perlin1.CalculatePerlin(0.5, 0.5);
        var result2 = perlin2.CalculatePerlin(0.5, 0.5);

        // Assert
        Assert.Equal(result1, result2);
    }
}