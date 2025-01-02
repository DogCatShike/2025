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
        for(int i = 0; i < heads.Length; i++)
        {
            GameObject head = heads[i];

            Renderer renderer = head.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Unlit/Color"));
            renderer.material.color = color;

            GameObject tile = head.transform.Find("Tile").gameObject;
            tile = tile.transform.Find("Tile").gameObject;
            Renderer tileRenderer = tile.GetComponent<Renderer>();
            tileRenderer.material = new Material(Shader.Find("Standard"));
            tileRenderer.material.SetFloat("_Mode", 3);
            tileRenderer.material.color = color;
        }
    }

    public void SetScale(float dt)
    {
        for(int i = 0; i < heads.Length; i++)
        {
            GameObject head = heads[i];

            Transform tile = head.transform.Find("Tile");
            tile.localScale += new Vector3(0, dt, 0);
        }
    }

    public void Move(float dt)
    {
        SetScale(dt);

        //TODO: 要算，但今天懒得算
        //先硬写吧，懒得算公式
        for(int i = 0; i < heads.Length; i++)
        {
            GameObject head = heads[i];

            Transform tile = head.transform.Find("Tile");
            tile.localScale += new Vector3(0, dt, 0);
        }
    }

    public void TearDown()
    {
        Destroy(gameObject);
    }
}