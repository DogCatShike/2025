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
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard/Transparent/Diffuse"));
        renderer.material.color = ;
    }
}