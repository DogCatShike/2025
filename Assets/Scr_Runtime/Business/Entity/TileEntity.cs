using HNY;
using System;
using UnityEngine;

public class TileEntity : MonoBehaviour
{
    public IDSignature idSig;

    public void Ctor()
    {

    }

    public void SetColor(Color color)
    {
        Transform tile = transform.Find("Tile");

        Renderer renderer = tile.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.SetFloat("_Mode", 3);
        renderer.material.color = color;
    }

    public void SetScale(float dt)
    {
        transform.localScale += new Vector3(0, dt, 0) * 5.5f;
    }

    public void TearDown()
    {
        Destroy(gameObject);
    }
}