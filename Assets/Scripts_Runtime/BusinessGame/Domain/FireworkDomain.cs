using System;
using UnityEditor;
using UnityEngine;

public static class FireworkDomain
{
    public static int id = 1;

    public static void CreateFirework(FireworkEntity fw, Transform parent)
    {
        fw.id = id;
        id++;

        fw.SetColor();
        fw.SetPosition();
        fw.SetSize();

        fw.CreateFirework(parent);
    }
}