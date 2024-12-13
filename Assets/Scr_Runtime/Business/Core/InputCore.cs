using System;
using UnityEngine;
using HNY;

public class InputCore
{
    public bool GetKeyDown()
    {
        if(Input.anyKeyDown)
        {
            return true;
        }
        return false;
    }
}