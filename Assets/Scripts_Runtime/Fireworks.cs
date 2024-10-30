using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Firework
{
    public GameObject gameObject;
    public Color color;
    public float sizeFactor;
    public float upLong;
    public bool isMoving;

    public Firework(GameObject obj, Color col, float scale)
    {
        gameObject = obj;
        color = col;
        sizeFactor = scale;
        upLong = sizeFactor * 30f + obj.transform.position.y; // 上升高度
        isMoving = true; // 初始化为正在移动
    }
}

public class Tile
{
    public GameObject gameObject;

    public Tile(GameObject obj)
    {
        gameObject = obj;
    }
}

public class Fireworks
{
    public static List<Firework> fireworks = new List<Firework>();
    public static List<Tile> tiles = new List<Tile>();
    static int num = -1;

    public static void CreateFireworks(Transform parent)
    {
        // 创建一个Cube作为像素点
        GameObject firework = GameObject.CreatePrimitive(PrimitiveType.Cube);
        firework.name = "firework";

        // 随机生成屏幕坐标
        Vector2 randomScreenPosition = new Vector2(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height));

        // 将屏幕坐标转换为世界坐标
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomScreenPosition.x, randomScreenPosition.y, Camera.main.nearClipPlane + 1));

        // 设置位置和父级
        firework.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0); 
        firework.transform.parent = parent;

        // 随机颜色
        Color fColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1);

        // 设置颜色材质
        Renderer renderer = firework.GetComponent<Renderer>();

        Material material = new Material(Shader.Find("Unlit/Color"));
        material.color = fColor;

        renderer.material = material;

        // 根据y坐标设置大小，越靠近顶部越小
        float screenHeight = Screen.height;

        // 获取随机y位置，并计算缩放因子（这里使用简单线性映射）
        float sizeFactor = Mathf.Lerp(0.2f, 0.05f, (randomScreenPosition.y / screenHeight));

        firework.transform.localScale = new Vector3(sizeFactor, sizeFactor, 1f);

        //添加组件
        Rigidbody rb = firework.AddComponent<Rigidbody>();
        rb.useGravity = false;
        BoxCollider bc = firework.GetComponent<BoxCollider>();
        bc.isTrigger = true;

        fireworks.Add(new Firework(firework, fColor, sizeFactor));
        num += 1;
    }

    public static void Up()
    {
        for (int i=0; i < fireworks.Count; i++)
        {
           Firework fw = fireworks[i];
           Rigidbody rb = fw.gameObject.GetComponent<Rigidbody>();

           if (fw.isMoving)
           {
               float fHeight = fw.gameObject.transform.position.y;

               if (fHeight < fw.upLong)
               {
                   rb.velocity= new Vector3(0 ,fw.sizeFactor * 15 ,0);
               }
               else 
               {
                   rb.velocity= Vector3.zero; 
                   fw.isMoving= false; // 停止移动状态 
               }
           }
        }
    }

    public static void CreateTiles(Transform parent)
    {
        Firework fw = fireworks[num];

        GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tile.name = "tile";
        
        tile.transform.parent = parent;

        Color tColor = new Color(fw.color.r, fw.color.g, fw.color.b, 0.9f);
            
        Renderer renderer = tile.GetComponent<Renderer>();

        Material material = new Material(Shader.Find("Standard")); // 着色器
        material.SetFloat("_Mode", 3); // 设置为透明模式
        material.color = tColor;

        renderer.material = material;

        tile.transform.localScale = new Vector3(fw.sizeFactor, fw.sizeFactor, 1f);
        
        tiles.Add(new Tile(tile));
        
    }

    public static void TileUp()
    {
        for (int i=0; i < tiles.Count; i++)
        {
            if(i >= fireworks.Count)
            {
                break;
            }

            Tile tile = tiles[i];
            Firework fw = fireworks[i];

            if(tile.gameObject.transform.localScale.y < fw.sizeFactor*8)
            {
                tile.gameObject.transform.localScale += new Vector3(0, 1.5f*Time.deltaTime, 0);
                tile.gameObject.transform.position = fw.gameObject.transform.position - new Vector3(0, tile.gameObject.transform.localScale.y/2, 0);
            } 

            else if(tile.gameObject.transform.localScale.y >= fw.sizeFactor*8)
            {
                tile.gameObject.transform.position = fw.gameObject.transform.position - new Vector3(0, fw.sizeFactor*4, 0);
            }
        }
    }
}
