using HNY;
using System;
using UnityEngine;

public class HeadEntity : MonoBehaviour
{
    public IDSignature idSig;

    public GameObject[] heads;

    public bool isMoving;

    public void Ctor()
    {
        heads = new GameObject[10];

        for (int i = 0; i < heads.Length; i++)
        {
            heads[i] = transform.Find("Head" + (i+1)).gameObject;
        }

        isMoving = true;
    }

    public void SetColor(Color color)
    {
        for(int i = 0; i < heads.Length; i++)
        {
            GameObject head = heads[i];

            Renderer renderer = head.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Custom/HeadShader"));
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

    public void Move(float dt, float size)
    {
        //TODO: 要算，但今天懒得算
        //先硬写吧，懒得算公式
        float[,] move = new float[10, 2]
        {
            {-12.5f, 55.3f},
            {-60.9f, 69.8f},
            {-92.9f, 78.1f},
            {-114.9f, 61.7f},
            {-155.4f, 52.8f},
            {-192.4f, 51.2f},
            {-219.4f, 58.3f},
            {-250.1f, 76.6f},
            {84.4f, 72.3f},
            {39.3f, 56.9f}
        };
        
        if(isMoving)
        {
            SetScale(dt);

            for(int i = 0; i < heads.Length; i++)
            {
                GameObject head = heads[i];
                
                float rot = move[i, 0];
                float dist = move[i, 1];
                dist = dist * size / 0.2f;

                head.transform.rotation = Quaternion.Euler(0, 0, rot);

                Vector3 dir = head.transform.up;
                head.transform.position += dir * dist * dt / 150;
                //2秒停止？
                //这个一点不严谨，都没计算

                //这合理吗？
                //改移动或者改停止，运动距离根据scale决定
                Invoke("Stop", 2);
            }
        }
    }

    public void Stop()
    {
        isMoving = false;
    }

    public void TearDown()
    {
        //这里要单独销毁数组的每个head吗？
        //应该不用
        Destroy(gameObject);
    }
}