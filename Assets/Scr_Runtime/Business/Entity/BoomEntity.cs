using HNY;
using System;
using UnityEngine;

public class BoomEntity : MonoBehaviour
{
    public IDSignature idSig;

    public void Ctor()
    {

    }

    public void SetColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Custom/RadialGradient"));
        renderer.material.color = color;
    }

    public void SetScale(float dt)
    {
        transform.localScale += new Vector3(dt, dt, 0) * 20;
    }

    public void Stop()
    {
        transform.localScale = transform.localScale;
    }

    public void TearDown()
    {
        Destroy(gameObject);
    }
}