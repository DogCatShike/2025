using System;
using UnityEngine;
using HNY;

public static class GameFactory
{
    public static FireworkEntity Firework_Create(GameContext ctx, int typeID, Transform parent)
    {
        GameObject go = ctx.assetsCore.Entity_GetFirework();
        go = GameObject.Instantiate(go, parent);

        FireworkEntity entity = go.GetComponent<FireworkEntity>();
        entity.Ctor();
        return entity;
    }
}