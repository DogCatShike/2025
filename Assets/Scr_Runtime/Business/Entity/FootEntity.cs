using System;
using UnityEngine;
using HNY;
using System.Collections;

public class FootEntity : MonoBehaviour
{
    public IDSignature idSig;

    public GameObject[] foots;

    int moveSpeed;

    public void Ctor()
    {
        foots = new GameObject[9];
        moveSpeed = 10;

        for (int i = 0; i < foots.Length; i++)
        {
            foots[i] = transform.Find("Foot" + (i+1)).gameObject;
        }
    }

    public void SetColor(Color color)
    {
        for(int i = 0; i < foots.Length; i++)
        {
            GameObject foot = foots[i];

            Renderer renderer = foot.GetComponent<Renderer>();
            //先用HeadShader, 一会改
            renderer.material = new Material(Shader.Find("Custom/HeadShader"));
            renderer.material.color = color;
        }
    }

    public void SetPos(HeadEntity head)
    {
        GameObject[] heads = head.heads;

        for (int i = 0; i < foots.Length; i++)
        {
            int j = i / 2;
            j = 6 - j;
            foots[i].transform.position = heads[j].transform.position;
        }

        foots[0].transform.position = (heads[7].transform.position + heads[6].transform.position) / 2;
    }

    public void Move(float dt)
    {

    }

    public void TearDown()
    {
        Destroy(gameObject);
    }
}