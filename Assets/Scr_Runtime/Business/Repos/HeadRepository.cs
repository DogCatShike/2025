using HNY;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HeadRepository
{
    Dictionary<IDSignature, HeadEntity> all;
    HeadEntity[] temArray;

    public HeadRepository()
    {
        all = new Dictionary<IDSignature, HeadEntity>();
        temArray = new HeadEntity[1000];
    }

    public void Add(HeadEntity entity)
    {
        all.Add(entity.idSig, entity);
    }

    public void Remove(HeadEntity entity)
    {
        all.Remove(entity.idSig);
    }

    public int TakeAll(out HeadEntity[] array)
    {
            if (all.Count > temArray.Length)
            {
                temArray = new HeadEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;
    }
    
    public bool TryGet(IDSignature idSig, out HeadEntity entity)
    {
        return all.TryGetValue(idSig, out entity);
    }
    //TODO
}