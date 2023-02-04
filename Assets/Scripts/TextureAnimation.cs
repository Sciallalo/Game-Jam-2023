using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class TextureAnimation : MonoBehaviour
{
    public Texture2D[] textures;

    public Material material;
    public int count = 0;

    private static readonly int Texture2D1 = Shader.PropertyToID("_Texture2D");

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().sharedMaterial;
        StartCoroutine(Animate());
    }

    public IEnumerator Animate()
    {
        count = 0;
        while (true)
        {
            if (count < textures.Length)
                material.SetTexture(Texture2D1, textures[count]);
            else count = 0;
            count++;
            yield return new WaitForSeconds(1/24f);
        }
    }
}
