using PerlinNoise;

public class PerlinTests
{
    [Fact]
    public void Permutation_ShouldReturnByteArrayWithLength256()
    {
        // Arrange
        var perlin = new Perlin();

        // Act
        var result = perlin.Permutation();

        // Assert
        Assert.Equal(256, result.Length);
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
}