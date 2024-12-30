using HNY;
using System;
using UnityEngine;

public static class BoomDomain
{
    public static BoomEntity Spawn(GameContext ctx, Transform parent)
    {
        BoomEntity entity = GameFactory.Boom_Create(ctx, parent);
        ctx.boomRepository.Add(entity);
        return entity;
    }

    public static void SetColor(BoomEntity entity, Color color)
    {
        entity.SetColor(color);
    }

    public static void SetScale(BoomEntity entity, float dt)
    {
        entity.SetScale(dt);
    }

    public static void Stop(BoomEntity entity)
    {
        entity.Stop();
    }

    public static void TearDown(BoomEntity entity)
    {
        entity.TearDown();
    }
}