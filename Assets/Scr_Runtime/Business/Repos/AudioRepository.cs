using System;
using UnityEngine;
using HNY;
using System.Collections.Generic;

public class AudioRepository
{
    Dictionary<IDSignature, AudioEntity> all;
    AudioEntity[] temArray;

    public AudioRepository()
    {
        all = new Dictionary<IDSignature, AudioEntity>();
        temArray = new AudioEntity[1000];
    }

    public void Add(AudioEntity entity)
    {
        all.Add(entity.idSig, entity);
    }

    public void Remove(AudioEntity entity)
    {
        all.Remove(entity.idSig);
    }

    public int TakeAll(out AudioEntity[] array)
    {
            if (all.Count > temArray.Length)
            {
                temArray = new AudioEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;
    }
    
    //TODO
}