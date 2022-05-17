using UnityEngine;

[ExecuteInEditMode]
public class TextureGenerator : MonoBehaviour
{
    [SerializeField] private int _width = 256;
    [SerializeField] private int _height = 256;

    [SerializeField] private float _scale = 20f;

    [SerializeField] private float _xOffset = 100f;
    [SerializeField] private float _yOffset = 100f;

    private Renderer _renderer;

    private void Update()
    {
        if (!_renderer)
            _renderer = GetComponent<Renderer>();
        _renderer.sharedMaterial.mainTexture = GenerateTexture();
    }

    private Texture GenerateTexture()
    {
        Texture2D texture = new Texture2D(_width, _height);

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                texture.SetPixel(x, y, CalculateColor(x, y));
            }
        }

        texture.Apply();
        return texture;
    }

    private Color CalculateColor(int x, int y)
    {
        float colorValue = PerlinNoiseCalculator.CalculatePerlinNoiseValue(x, y, _width, _height, _scale, _xOffset, _yOffset);
        return new Color(colorValue, colorValue, colorValue);
    }
}
