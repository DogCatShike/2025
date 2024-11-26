using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameContext ctx;

    void Awake()
    {
        ctx = new GameContext();
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            FireworkDomain.Spawn(ctx);
        }
    }
}
