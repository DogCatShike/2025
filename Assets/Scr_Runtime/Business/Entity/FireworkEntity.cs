using System;
using UnityEngine;
using HNY;

public class FireworkEntity : MonoBehaviour
{
    public IDSignature idSig;
    public int typeID;

    [HideInInspector]public Vector3 pos;
    [HideInInspector]public Color color;
    [HideInInspector]public float size;
    
    public bool isMoving;

    public void Ctor()
    {
        isMoving = true;

        SetPos();
        SetColor();
        SetSize();

        transform.position = pos;

        Renderer renderer = GetComponent<Renderer>();
        Material material = new Material(Shader.Find("Unlit/Color"));
        material.color = color;

        transform.localScale = new Vector3(size, size, 1);
    }

    //直接把屏幕宽高存下来应该比较好，先这么写，之后改
    public void SetPos()
    {
        pos = new Vector3(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height/4*3), 0);
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;
    }

    public void SetColor()
    {
        color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1);
    }

    public void SetSize()
    {
        size = Mathf.Lerp(0.2f, 0.05f, pos.y/Screen.height);
    }

    public void TearDown()
    {
        Destroy(gameObject);
    }
}