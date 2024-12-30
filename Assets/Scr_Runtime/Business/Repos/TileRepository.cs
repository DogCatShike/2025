using System;
using UnityEngine;
using HNY;
using System.Collections.Generic;

public class TileRepository
{
    Dictionary<IDSignature, TileEntity> all;
    TileEntity[] temArray;

    public TileRepository()
    {
        all = new Dictionary<IDSignature, TileEntity>();
        temArray = new TileEntity[1000];
    }

    public void Add(TileEntity entity)
    {
        all.Add(entity.idSig, entity);
    }

    public void Remove(TileEntity entity)
    {
        all.Remove(entity.idSig);
    }

    public int TakeAll(out TileEntity[] array)
    {
            if (all.Count > temArray.Length)
            {
                temArray = new TileEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;
    }
    
    //TODO
}