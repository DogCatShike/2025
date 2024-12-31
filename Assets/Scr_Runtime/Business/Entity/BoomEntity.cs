using HNY;
using System;
using UnityEngine;

public class BoomEntity : MonoBehaviour
{
    public IDSignature idSig;

    public float alpha = 1;

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

    public void SetAlpha(float dt)
    {
        alpha -= dt * 1.5f;

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetFloat("_Transparency", alpha);
    }

    public void TearDown()
    {
        Destroy(gameObject);
    }
}