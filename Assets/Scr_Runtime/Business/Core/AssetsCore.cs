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

    public GameObject Entity_GetFirework()
    {
        entities.TryGetValue("Entity_Firework", out GameObject entity);
        if (entity == null) 
        {
            Debug.LogError("Entity_Firework is null");
        }
        return entity;
    }
}