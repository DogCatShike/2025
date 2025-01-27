using System;
using UnityEngine;
using HNY;
using System.Collections.Generic;

public class FootRepository
{
    Dictionary<IDSignature, FootEntity> all;
    FootEntity[] temArray;

    public FootRepository()
    {
        all = new Dictionary<IDSignature, FootEntity>();
        temArray = new FootEntity[1000];
    }

    public void Add(FootEntity entity)
    {
        all.Add(entity.idSig, entity);
    }

    public void Remove(FootEntity entity)
    {
        all.Remove(entity.idSig);
    }

    public int TakeAll(out FootEntity[] array)
    {
            if (all.Count > temArray.Length)
            {
                temArray = new FootEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;
    }
    
    //TODO
}