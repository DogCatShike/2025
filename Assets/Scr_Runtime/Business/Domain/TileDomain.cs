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

    public static void TearDown(TileEntity entity)
    {
        entity.TearDown();
    }
}