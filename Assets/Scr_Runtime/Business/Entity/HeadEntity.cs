using HNY;
using System;
using UnityEngine;

public class HeadEntity : MonoBehaviour
{
    public IDSignature idSig;

    public GameObject[] heads;

    public void Ctor()
    {
        heads = new GameObject[10];

        for (int i = 0; i < heads.Length; i++)
        {
            heads[i] = transform.Find("Head" + (i+1)).gameObject;
        }
    }

    public void SetColor(Color color)
    {
        for (int i = 0; i < heads.Length; i++)
        {
            GameObject head = heads[i];

            Renderer renderer = head.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Unlit/Color"));
            renderer.material.color = color;
        }
    }

    public void Move()
    {
        //TODO: 要算，但今天懒得算
    }

    public void TearDown()
    {
        Destroy(gameObject);
    }
}