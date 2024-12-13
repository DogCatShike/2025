using System;
using UnityEngine;
using HNY;
using System.Collections.Generic;

public class FireworkRepository
{
    Dictionary<IDSignature, FireworkEntity> all;
    FireworkEntity[] temArray;

    public FireworkRepository()
    {
        all = new Dictionary<IDSignature, FireworkEntity>();
        temArray = new FireworkEntity[1000];
    }

    public void Add(FireworkEntity entity)
    {
        all.Add(entity.idSig, entity);
    }

    public void Remove(FireworkEntity entity)
    {
        all.Remove(entity.idSig);
    }

    public int TakeAll(out FireworkEntity[] array)
    {
            if (all.Count > temArray.Length)
            {
                temArray = new FireworkEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;
    }
    
    //TODO
}