using System;
using UnityEngine;
using HNY;
using System.Collections;

public class FootEntity : MonoBehaviour
{
    public IDSignature idSig;

    public GameObject[] foots;

    public float moveSpeed;
    public float[] moveDists;

    public int[] maxCopys;
    public int[] copyCounts;

    bool[] isMoving;

    public float alpha;

    LineRenderer[] lineRenderers;
    float[] lineTimes;

    public void Ctor()
    {
        foots = new GameObject[9];

        maxCopys = new int[9];
        copyCounts = new int[9];
        
        moveSpeed = 10;
        moveDists = new float[9];

        isMoving = new bool[9];

        alpha = 0.8f;

        lineRenderers = new LineRenderer[9];
        lineTimes = new float[9];

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

    public void SetAlpha(float dt)
    {
        alpha -= dt * 1.2f;

        for(int i = 0; i < foots.Length; i++)
        {
            GameObject foot = foots[i];

            Renderer renderer = foot.GetComponent<Renderer>();
            renderer.material.SetFloat("_Transparency", alpha);
        }
    }

    public void SetPos(HeadEntity head)
    {
        GameObject[] heads = head.heads;

        for (int i = 0; i < foots.Length; i++)
        {
            if(foots[i].transform.localPosition == Vector3.zero)
            {
                int j = i / 2;
                j = 6 - j;
                foots[i].transform.position = heads[j].transform.position;

                foots[0].transform.position = (heads[7].transform.position + heads[6].transform.position) / 2;
            }
        }
    }

    public void SetMisc()
    {
        for (int i = 0; i < foots.Length; i++)
        {
            maxCopys[i] = UnityEngine.Random.Range(2, 8);
            copyCounts[i] = 0;
            moveDists[i] = 0;
            lineRenderers[i] = foots[i].GetComponent<LineRenderer>();
            lineTimes[i] = 0.1f;
        }
    }

    public void SetLine(Color color)
    {
        float hue, saturation, value;
        Color.RGBToHSV(color, out hue, out saturation, out value);
        Color lineColor = Color.HSVToRGB(hue, saturation, 0.7f);

        for (int i = 0; i < lineRenderers.Length; i++)
        {
            LineRenderer lineRenderer = lineRenderers[i];

            lineRenderer.positionCount = 0;
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.material = new Material(Shader.Find("Standard"));
            lineRenderer.material.SetFloat("_Mode", 3);
            lineRenderer.material.color = lineColor;
        }
    }

    #region Move
    public void Move(float dt, float size)
    {
        for (int i = 0; i < foots.Length; i++)
        {
            GameObject foot = foots[i];

            int maxCopy = maxCopys[i];
            int copyCount = copyCounts[i];

            float maxMove = Mathf.Lerp(3, 1, (maxCopy - 2) / 6f);

            bool isStop = StopMove(i, maxMove, dt);

            isMoving[i] = true;

            LineRenderer line = lineRenderers[i];

            if (copyCount >= maxCopy)
            {
                isMoving[i] = false;
                continue;
            }

            if (!isStop)
            {
                StartMove(dt, foot, size, line, i);
            }
            else
            {
                if (copyCount < maxCopy)
                {
                    GameObject newFoot = CopySelf(i, foot);
                    StartMove(dt, newFoot, size, line, i);
                }
                moveDists[i] = 0;
            }
        }
    }

    public void StartMove(float dt, GameObject foot, float size, LineRenderer line, int i)
    {
        float randomX = UnityEngine.Random.Range(-10, 10);
        float multiple = Mathf.Lerp(0, 1, size / 0.2f);
        foot.transform.position += new Vector3(randomX, -moveSpeed / 3, 0) * dt * multiple;

        lineTimes[i] += dt;
        if (lineTimes[i] >= 0.1f)
        {
            DrawLine(line, foot.transform.position);
            lineTimes[i] = 0;
        }
    }

    public bool StopMove(int i, float maxMove, float dt)
    {
        moveDists[i] += moveSpeed * dt;

        if (moveDists[i] >= maxMove)
        {
            return true;
        }

        return false;
    }

    public GameObject CopySelf(int i, GameObject foot)
    {
        copyCounts[i]++;
        GameObject newFoot = Instantiate(foot.gameObject, foot.transform.parent);
        return newFoot;
    }

    public bool IsMoving()
    {
        foreach (bool isMove in isMoving)
        {
            if (isMove)
            {
                return true;
            }
        }

        return false;
    }

    private void DrawLine(LineRenderer line, Vector3 position)
    {
        line.positionCount++;
        line.SetPosition(line.positionCount - 1, position);
    }

    #endregion

    public void TearDown()
    {
        Destroy(gameObject);
    }
}