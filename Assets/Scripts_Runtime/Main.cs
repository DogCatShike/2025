using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    bool build = false;

    void Awake()
    {
    }

    void Update()
    {
        if(Input.anyKey && !build)
        {
            build = true;

            GameObject f = new GameObject("f");

            Fireworks.CreateFireworks(f.transform);
            Fireworks.CreateTiles(f.transform);

            Booms.AddFirework(f);
        }

        if(!Input.anyKey)
        {
            build = false;
        }

        Fireworks.Up();
        Fireworks.TileUp();
        Booms.RemoveFirework();
    }
}
