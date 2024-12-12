using System;
using UnityEngine;
using HNY;
using System.Collections.Generic;

public class FireworkRepository
{
    Dictionary<int, FireworkEntity> all;
    FireworkEntity[] temArray;

    public FireworkRepository()
    {
        all = new Dictionary<int, FireworkEntity>();
        temArray = new FireworkEntity[1000];
    }

    public void Add(FireworkEntity entity)
    {
        all.Add(entity.id, entity);
    }

    public void Remove(FireworkEntity entity)
    {
        all.Remove(entity.id);
    }

    //TODO
}