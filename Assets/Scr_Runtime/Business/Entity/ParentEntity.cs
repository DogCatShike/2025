using System;
using UnityEngine;
using HNY;

public class ParentEntity : MonoBehaviour
{
    public IDSignature idSig;

    [SerializeField]Rigidbody2D rb;

    [HideInInspector]public Vector3 pos;
    [HideInInspector]public Color color;
    [HideInInspector]public float size;
    
    public Vector3 beforePos;
    public float moveSpeed;
    public bool isMoving;

    public void Ctor()
    {
        SetPos();
        SetSize();

        transform.position = pos;

        //刚才忘了改，发现只控制他的scale也不错
        transform.localScale = new Vector3(size, size, 1);

        rb = GetComponent<Rigidbody2D>();
        moveSpeed = size * 10;
    }

    //直接把屏幕宽高存下来应该比较好，先这么写，之后改
    public void SetPos()
    {
        pos = new Vector3(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height/4*3), 0);
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;

        beforePos = pos;
    }

    public Color SetColor()
    {
        color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1);
        return color;
    }

    //暂时这样，脑子不够用了
    public void SetSize()
    {
        size = Mathf.Lerp(0.2f, 0.05f, pos.y/2);
        //Debug.Log("size: " + size);
    }

    public void Move()
    {            
        Vector2 pos = rb.velocity;
        pos.y = moveSpeed;
        rb.velocity = pos;
    }

    public void Stop()
    {
        isMoving = false;

        rb.velocity = Vector2.zero;
    }

    public void TearDown()
    {
        Destroy(gameObject);
    }
}