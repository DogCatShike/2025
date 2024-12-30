using System;
using UnityEngine;
using HNY;
using System.Collections.Generic;

public class BoomRepository
{
    Dictionary<IDSignature, BoomEntity> all;
    BoomEntity[] temArray;

    public BoomRepository()
    {
        all = new Dictionary<IDSignature, BoomEntity>();
        temArray = new BoomEntity[1000];
    }

    public void Add(BoomEntity entity)
    {
        all.Add(entity.idSig, entity);
    }

    public void Remove(BoomEntity entity)
    {
        all.Remove(entity.idSig);
    }

    public int TakeAll(out BoomEntity[] array)
    {
            if (all.Count > temArray.Length)
            {
                temArray = new BoomEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;
    }
    
    //TODO
}