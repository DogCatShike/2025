using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameFactory
{
    public static int fireworkId = 1;
    
    public static FireworkEntity CreateFirework(GameContext ctx, Transform parent)
    {
        GameObject prefab = ctx.assetsCore.EntityGetFirework();
        GameObject firework = GameObject.Instantiate(prefab, parent);
        FireworkEntity entity = firework.GetComponent<FireworkEntity>();

        entity.id = fireworkId++;

        entity.Ctor();
        entity.SetColor();
        entity.SetPosition();
        entity.SetSize();

        return entity;
    }
}
