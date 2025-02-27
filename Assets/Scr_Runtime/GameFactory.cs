using System;
using UnityEngine;
using HNY;

public static class GameFactory
{
    public static ParentEntity Parent_Create(GameContext ctx)
    {
        GameObject go = ctx.assetsCore.Entity_GetParent();
        go = GameObject.Instantiate(go);

        ParentEntity entity = go.GetComponent<ParentEntity>();

        entity.idSig.entityType = EntityType.Parent;
        entity.idSig.entityID = ctx.idService.parentID++;

        entity.Ctor();
        return entity;
    }

    public static FireworkEntity Firework_Create(GameContext ctx, Transform parent)
    {
        GameObject go = ctx.assetsCore.Entity_GetFirework();
        go = GameObject.Instantiate(go, parent);

        FireworkEntity entity = go.GetComponent<FireworkEntity>();

        entity.idSig.entityType = EntityType.Firework;
        entity.idSig.entityID = ctx.idService.fireworkID++;

        entity.Ctor();
        return entity;
    }

    public static BoomEntity Boom_Create(GameContext ctx, Transform parent)
    {
        GameObject go = ctx.assetsCore.Entity_GetBoom();
        go = GameObject.Instantiate(go, parent);

        BoomEntity entity = go.GetComponent<BoomEntity>();

        entity.idSig.entityType = EntityType.Boom;
        entity.idSig.entityID = ctx.idService.boomID++;

        entity.Ctor();
        return entity;
    }

    public static TileEntity Tile_Create(GameContext ctx, Transform parent)
    {
        GameObject go = ctx.assetsCore.Entity_GetTile();
        go = GameObject.Instantiate(go, parent);

        TileEntity entity = go.GetComponent<TileEntity>();

        entity.idSig.entityType = EntityType.Tile;
        entity.idSig.entityID = ctx.idService.tileID++;

        entity.Ctor();
        return entity;
    }

    public static HeadEntity Head_Create(GameContext ctx, Transform parent)
    {
        GameObject go = ctx.assetsCore.Entity_GetHead();
        go = GameObject.Instantiate(go, parent);

        HeadEntity entity = go.GetComponent<HeadEntity>();

        entity.idSig.entityType = EntityType.Head;
        entity.idSig.entityID = ctx.idService.headID++;

        entity.Ctor();
        return entity;
    }

    public static AudioEntity Audio_Create(GameContext ctx)
    {
        GameObject go = ctx.assetsCore.Entity_GetAudio();
        go = GameObject.Instantiate(go);

        AudioEntity entity = go.GetComponent<AudioEntity>();

        entity.idSig.entityType = EntityType.Audio;
        entity.idSig.entityID = ctx.idService.audioID++;

        entity.Ctor();
        return entity;
    }

    public static FootEntity Foot_Create(GameContext ctx, Transform parent)
    {
        GameObject go = ctx.assetsCore.Entity_GetFoot();
        go = GameObject.Instantiate(go, parent);

        FootEntity entity = go.GetComponent<FootEntity>();

        entity.idSig.entityType = EntityType.Foot;
        entity.idSig.entityID = ctx.idService.footID++;

        entity.Ctor();
        return entity;
    }
}