using HNY;
using System;
using UnityEngine;

public class HeadEntity : MonoBehaviour
{
    public IDSignature idSig;

    public GameObject[] heads;

    public bool isMoving;

    public float alpha;

    public void Ctor()
    {
        heads = new GameObject[10];

        for (int i = 0; i < heads.Length; i++)
        {
            heads[i] = transform.Find("Head" + (i+1)).gameObject;
        }

        isMoving = true;
        alpha = 0.8f;
    }

    public void SetColor(Color color)
    {
        //提高颜色饱和度（RGBToHSV: Color转换为HSV模型，三个返回值分别为色相 饱和度 明度）
        float hue, saturation, value;
        Color.RGBToHSV(color, out hue, out saturation, out value);
        Color tileColor = Color.HSVToRGB(hue, saturation, 1.0f);

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
            tileRenderer.material.color = tileColor;
        }
    }

    public void SetScale(float dt)
    {
        for(int i = 0; i < heads.Length; i++)
        {
            GameObject head = heads[i];

            Transform tile = head.transform.Find("Tile");
            tile.localScale += new Vector3(0, dt, 0) * 8f;
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
                head.transform.position += dir * dist * dt / 20;
                
                //2秒停止？
                //这个一点不严谨，都没计算
                //这合理吗？
                //改移动或者改停止，运动距离根据scale决定
                // Invoke("Stop", 2);
            }

            if(heads[2].transform.localPosition.x >= 5.15)
            {
                isMoving = false;
            }
        }
    }

    public void Stop()
    {
        isMoving = false;
    }

    public bool SetTileScale(float dt)
    {
        for(int i = 0; i < heads.Length; i++)
        {
            GameObject head = heads[i];
            GameObject tile = head.transform.Find("Tile").gameObject;

            tile.transform.localScale -= new Vector3(0, dt, 0) * 3.5f;

            if(tile.transform.localScale.y <= 1)
            {
                return true;
            }
        }
        return false;
    }

    public void SetHeadAlpha(float dt)
    {
        alpha -= dt * 1.2f;

        for(int i = 0; i < heads.Length; i++)
        {
            GameObject head = heads[i];

            Renderer renderer = head.GetComponent<Renderer>();
            renderer.material.SetFloat("_Transparency", alpha);
        }
    }

    public void TearDown()
    {
        //这里要单独销毁数组的每个head吗？
        //应该不用
        Destroy(gameObject);
    }
}