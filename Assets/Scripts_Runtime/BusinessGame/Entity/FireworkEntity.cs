using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FireworkEntity : MonoBehaviour
{
    public int id;
    public int typeID;
    public GameObject prefab;
    public Color color;
    public Material material;
    public Vector3 position;
    public float size;
    public float upLong;
    public bool isMoving;
    private GameObject parent;

    public void Ctor()
    {
        material = new Material(Shader.Find("Unlit/Color"));
    }

    public void SetColor()
    {
        color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1);
    }

    public void SetPosition()
    {
        Vector2 screenPosition = new Vector2(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height));
        position = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane + 1));
    }

    public void SetSize()
    {
        float screenHeight = Screen.height;
        size = Mathf.Lerp(0.2f, 0.05f, (position.y / screenHeight));
    }

    public void Disappear()
    {
        Destroy(parent);
        parent = null;
        Destroy(gameObject);
    }

    public void SetParent(GameObject newParent)
    {
        parent = newParent;
        transform.parent = newParent.transform;
    }

    /*public void CreateFirework(Transform parent)
    {
        GameObject firework = Instantiate(prefab, parent);
        firework.name = "firework";

        Renderer renderer = firework.GetComponent<Renderer>();
        material.color = color;
        renderer.material = material;

        firework.transform.position = position;
        firework.transform.parent = parent;
        firework.transform.localScale = new Vector3(size, size, 1);

        Rigidbody rb = firework.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }*/
}