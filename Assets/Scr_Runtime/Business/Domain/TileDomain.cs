using HNY;
using System;
using UnityEngine;

public static class TileDomain
{
    public static TileEntity Spawn(GameContext ctx, Transform parent)
    {
        TileEntity entity = GameFactory.Tile_Create(ctx, parent);
        ctx.tileRepository.Add(entity);
        return entity;
    }

    public static void SetColor(TileEntity entity, Color color)
    {
        entity.SetColor(color);
    }

    public static void SetScale(TileEntity entity, float dt)
    {
        entity.SetScale(dt);
    }

    public static void TearDown(TileEntity entity, GameContext ctx)
    {
        ctx.tileRepository.Remove(entity);
        entity.TearDown();
    }

    public static void Clear(GameContext ctx)
    {
        int len = ctx.tileRepository.TakeAll(out TileEntity[] entities);
        for (int i = 0; i < len; i++)
        {
            TileEntity entity = entities[i];
            TearDown(entity, ctx);
        }
    }
}