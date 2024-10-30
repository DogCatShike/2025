using System;
using System.Collections.Generic;
using UnityEngine;

public class Boom
{
    public GameObject gameObject;
    public Vector3 createPos;
    public bool check = false;
    public bool fwIsMoving = true;

    public Boom(GameObject f)
    {
        gameObject = f;
    }
}

public class Booms: MonoBehaviour
{
    public static List<Boom> booms = new List<Boom>();

    public static void AddFirework(GameObject f)
    {
        booms.Add(new Boom(f));
    }

    public static void RemoveFirework()
    {
        Firework fw = null;
        
        for(int i=0; i<booms.Count; i++)
        {
            if(booms[i].gameObject.transform.Find("firework") != null)
            {
                fw = Fireworks.fireworks[i];
                booms[i].fwIsMoving = fw.isMoving;
                booms[i].createPos = fw.gameObject.transform.position;
                continue;
            }
        }
    }
}