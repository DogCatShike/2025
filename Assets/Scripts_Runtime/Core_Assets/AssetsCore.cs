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

    public async Task<GameObject> LoadFirework()
    {
        var handle = Addressables.LoadAssetAsync<GameObject>("Entity_Firework");

        await handle.Task; // 等待加载完成

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            return handle.Result; // 返回加载的 prefab
        }

        Debug.LogError($"Failed to load prefab at address");
        return null;
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
