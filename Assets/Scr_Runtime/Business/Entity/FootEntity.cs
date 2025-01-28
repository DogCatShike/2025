using System;
using UnityEngine;
using HNY;
using System.Collections;

public class FootEntity : MonoBehaviour
{
    public IDSignature idSig;

    public GameObject[] foots;
    public int[] maxCopy;
    public int[] copyNumbers;
    public float[] moveDist;
    public float[] footYPos;

    public float moveSpeed;

    public void Ctor()
    {
        foots = new GameObject[9];
        maxCopy = new int[9];
        copyNumbers = new int[9];
        moveDist = new float[9];
        footYPos = new float[9];
        moveSpeed = 10;

        for (int i = 0; i < foots.Length; i++)
        {
            foots[i] = transform.Find("Foot" + (i+1)).gameObject;

            maxCopy[i] = UnityEngine.Random.Range(2, 8);
            copyNumbers[i] = 0;
            moveDist[i] = 0;
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

            footYPos[i] = foots[i].transform.position.y;
        }

        foots[0].transform.position = (heads[7].transform.position + heads[6].transform.position) / 2;
        footYPos[0] = foots[0].transform.position.y;
    }

    public void Move(float dt)
    {
        // for (int i = 0; i < foots.Length; i++)
        // {
        //     if (copyNumbers[i] < randomNumbers[i])
        //     {
        //         float y = transform.position.y;
        //         float maxMove = Mathf.Lerp(5, 1, (randomNumbers[i] - 2) / 6);

        //         if (y <= footYPos[i] - maxMove)
        //         {
        //             float randomX = UnityEngine.Random.Range(-1f, 1f);

        //             Vector3 newPos = new Vector3(randomX * dt, moveSpeed * dt);
        //             transform.position += newPos;
        //         }
        //         else
        //         {
        //             copyNumbers[i]++;
        //             CopySelf();
        //         }
        //     }
        // }

        for (int i = 0; i < foots.Length; i++)
        {
            if (copyNumbers[i] < maxCopy[i])
            {
                float maxMove = Mathf.Lerp(5, 1, (maxCopy[i] - 2) / 6);

                float randomX = UnityEngine.Random.Range(-1f, 1f);
                foots[i].transform.position -= new Vector3(randomX * dt, moveSpeed * dt);
                moveDist[i] += moveSpeed * dt;

                if(moveDist[i] >= footYPos[i] - maxMove)
                {
                    CopySelf();
                    moveDist[i] = 0;
                }
            }
        }
    }

    public void CopySelf()
    {
        GameObject foot = Instantiate(gameObject, transform.position, transform.rotation);
        foot.GetComponent<FootEntity>().copyNumbers = (int[])copyNumbers.Clone();
        
        for (int i = 0; i < copyNumbers.Length; i++)
        {
            copyNumbers[i]++;
        }
    }

    public void TearDown()
    {
        Destroy(gameObject);
    }
}