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
            GameObject fw = new GameObject("fw");
            FireworkEntity firework = fw.AddComponent<FireworkEntity>();
            Transform parent = fw.transform;
            FireworkDomain.CreateFirework(firework, parent);
        }
    }
}
