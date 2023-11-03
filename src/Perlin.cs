using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerlinNoise;

public class Perlin
{
    public double OctavePerlin(double x, double y, int octaves, double persistence, double lacunarity)
	{

		double total = 0;
		double frequency = 1;
		double amplitude = 1;
		for (int i = 0; i < octaves; i++)
		{
			total += CalculatePerlin(x * frequency, y * frequency) * amplitude;

			amplitude *= persistence;
			frequency *= lacunarity;
		}

		return total;
	}
	// set a seed value for the permutation vector
	private int seed = 0;
	public void SetSeed(int seed)
	{
		this.seed = seed;
	}
	//Generate a new permutation vector based on the value of seed
	public byte[] Permutation()
	{
		for (byte i = 0; i <= 255; i++)
		{
			p[i] = i;
		}
		Random random = new(seed);
		// Fisher-Yates shuffle algorithm
		for (int i = p.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            // Swap p[i] and p[j]
            (p[j], p[i]) = (p[i], p[j]);
        }
        return p;
	}
	private readonly byte[] p;

    public Perlin()
	{
		p = Permutation();
	}

	public double CalculatePerlin(double x, double y)
	{
		throw new NotImplementedException();
	}
}
