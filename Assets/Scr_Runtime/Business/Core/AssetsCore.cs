using System;
using UnityEngine;
using HNY;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class AssetsCore
{
    public Dictionary<string, GameObject> entities;
    public AsyncOperationHandle entitiesHandle;

    public AssetsCore()
    {
        entities = new Dictionary<string, GameObject>();
    }

    public void LoadAll()
    {
        AssetLabelReference labelReference = new AssetLabelReference();
        labelReference.labelString = "Entity";
        var ptr = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
        var list = ptr.WaitForCompletion();
        foreach (var go in list) 
        {
            entities.Add(go.name, go);
        }
        entitiesHandle = ptr;
    }

    public void UnloadAll()
    {
        if(entitiesHandle.IsValid())
        {
            Addressables.Release(entitiesHandle);
        }
    }

    public GameObject Entity_GetParent()
    {
        entities.TryGetValue("Entity_Parent", out GameObject entity);
        return entity;
    }

    public GameObject Entity_GetFirework()
    {
        entities.TryGetValue("Entity_Firework", out GameObject entity);
        return entity;
    }

    public GameObject Entity_GetBoom()
    {
        entities.TryGetValue("Entity_Boom", out GameObject entity);
        return entity;
    }
}