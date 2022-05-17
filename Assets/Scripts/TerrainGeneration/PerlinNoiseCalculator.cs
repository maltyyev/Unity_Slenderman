using UnityEngine;

public static class PerlinNoiseCalculator
{
    public static float CalculatePerlinNoiseValue(int x, int y, int width, int height, float scale, float xOffset, float yOffset)
    {
        float xPerlin = (float)x / width * scale + xOffset;
        float yPerlin = (float)y / height * scale + yOffset;

        return Mathf.PerlinNoise(xPerlin, yPerlin);
    }
}
