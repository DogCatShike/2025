using System;
using System.Collections.Generic;
using UnityEditor;

public class FireworkRepository
{
    Dictionary<int, FireworkEntity> fwDict;

    public FireworkRepository()
    {
        fwDict = new Dictionary<int, FireworkEntity>();
    }

    public void Add(FireworkEntity fw)
    {
        fwDict.Add(fw.id, fw);
    }

    public void Remove(FireworkEntity fw)
    {
        fwDict.Remove(fw.id);
    }
}