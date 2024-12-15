using System;
using UnityEngine;
using HNY;
using System.Collections.Generic;

public class ParentRepository
{
    Dictionary<IDSignature, ParentEntity> all;
    ParentEntity[] temArray;

    public ParentRepository()
    {
        all = new Dictionary<IDSignature, ParentEntity>();
        temArray = new ParentEntity[1000];
    }

    public void Add(ParentEntity entity)
    {
        all.Add(entity.idSig, entity);
    }

    public void Remove(ParentEntity entity)
    {
        all.Remove(entity.idSig);
    }

    public int TakeAll(out ParentEntity[] array)
    {
            if (all.Count > temArray.Length)
            {
                temArray = new ParentEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;
    }
    
    //TODO
}