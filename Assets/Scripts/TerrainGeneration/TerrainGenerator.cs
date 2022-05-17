using UnityEngine;

[ExecuteInEditMode]
public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int _width = 256;
    [SerializeField] private int _height = 256;
    [SerializeField] private int _depth = 20;

    [SerializeField] private float _scale = 20f;

    [SerializeField] private float _xOffset = 100f;
    [SerializeField] private float _yOffset = 100f;

    Terrain _terrain;

    void Update()
    {
        if (!_terrain)
            _terrain = GetComponent<Terrain>();
        _terrain.terrainData = GenerateTerrain(_terrain.terrainData);
    }

    private TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = _width + 1;
        terrainData.size = new Vector3(_width, _depth, _height);

        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    private float[,] GenerateHeights()
    {
        float[,] heights = new float[_width, _height];
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    private float CalculateHeight(int x, int y)
    {
        return PerlinNoiseCalculator.CalculatePerlinNoiseValue(x, y, _width, _height, _scale, _xOffset, _yOffset);
    }
}
