using System;
using UnityEngine;
using HNY;

public static class GameFactory
{
    public static ParentEntity Parent_Create(GameContext ctx, int typeID)
    {
        GameObject go = ctx.assetsCore.Entity_GetParent();
        go = GameObject.Instantiate(go);

        ParentEntity entity = go.GetComponent<ParentEntity>();

        entity.idSig.entityType = EntityType.Parent;
        entity.idSig.entityID = ctx.idService.parentID++;

        entity.Ctor();
        return entity;
    }

    public static FireworkEntity Firework_Create(GameContext ctx, int typeID, Transform parent)
    {
        GameObject go = ctx.assetsCore.Entity_GetFirework();
        go = GameObject.Instantiate(go, parent);

        FireworkEntity entity = go.GetComponent<FireworkEntity>();

        entity.idSig.entityType = EntityType.Firework;
        entity.idSig.entityID = ctx.idService.fireworkID++;

        entity.Ctor();
        return entity;
    }
}