using UnityEngine;
using UnityEngine.UI;

public class anaglyph : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public RawImage rawImage;
    public RenderTexture left;
    public RenderTexture right;

    private Texture2D texture;
    void Start()
    {
        texture = new Texture2D(left.width, left.height, TextureFormat.RGBA32, false);
    }

    // Update is called once per frame
    void Update()
    {
        //texture = new Texture2D(left.width, left.height, TextureFormat.RGBA32, false);
        RenderTexture.active = left;
        texture.ReadPixels(new Rect(0, 0, left.width, left.height), 0, 0);
        texture.Apply();
        Color[] leftPixels = texture.GetPixels();

        RenderTexture.active = null;

        RenderTexture.active = right;
        texture.ReadPixels(new Rect(0, 0, right.width, right.height), 0, 0);
        texture.Apply();
        Color[] rightPixels = texture.GetPixels();

        Color[] results = new Color[leftPixels.Length];

        for (int i = 0; i < leftPixels.Length; i++)
        {
            results[i] = new Color(leftPixels[i].r, rightPixels[i].g, rightPixels[i].b, leftPixels[i].a);
        }

        if (texture == null)
        {
            print("texture null");
        }
        else
        {
            texture.SetPixels(results);
            texture.Apply();
        }

        rawImage.texture = texture;
    }
}
