using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetsCore//完全不熟悉这些语法
{
    public Dictionary<string, GameObject> entities;
    public AsyncOperationHandle entitiesHandle;

    public AssetsCore()
    {
        entities = new Dictionary<string, GameObject>();
    }

    public async Task LoadAll()
    {
        AssetLabelReference labelReference = new AssetLabelReference();

        labelReference.labelString = "Entity";
        var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);

        var all = await handle.Task;
        foreach(var item in all)
        {
            entities.Add(item.name, item);
        }

        entitiesHandle = handle;
    }

    public void UnLoadAll()
    {
        if(entitiesHandle.IsValid())
        {
            Addressables.Release(entitiesHandle);
            entitiesHandle = default;
        }
    }

    public GameObject EntityGetFirework()
    {
        entities.TryGetValue("Entity_Firework", out GameObject firework);
        return firework;
    }
}
