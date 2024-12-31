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

    public static void SetAlpha(BoomEntity entity, float dt)
    {
        entity.SetAlpha(dt);
    }

    public static void TearDown(BoomEntity entity, GameContext ctx)
    {
        ctx.boomRepository.Remove(entity);
        entity.TearDown();
    }

    public static void Clear(GameContext ctx)
    {
        int len = ctx.boomRepository.TakeAll(out BoomEntity[] entities);
        for (int i = 0; i < len; i++)
        {
            BoomEntity entity = entities[i];
            TearDown(entity, ctx);
        }
    }
}