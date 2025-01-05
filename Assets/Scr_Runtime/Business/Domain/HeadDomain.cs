using HNY;
using System;
using UnityEngine;

public static class HeadDomain
{
    public static HeadEntity Spawn(GameContext ctx, Transform parent)
    {
        HeadEntity entity = GameFactory.Head_Create(ctx, parent);
        ctx.headRepository.Add(entity);
        return entity;
    }

    public static void SetColor(HeadEntity head, Color color)
    {
        head.SetColor(color);
    }

    public static void Move(HeadEntity head, float dt, float size)
    {
        head.Move(dt, size);
    }

    public static void TearDown(HeadEntity head, GameContext ctx)
    {
        ctx.headRepository.Remove(head);
        head.TearDown();
    }

    public static void Clear(GameContext ctx)
    {
        int len = ctx.headRepository.TakeAll(out HeadEntity[] entities);
        for (int i = 0; i < len; i++)
        {
            HeadEntity entity = entities[i];
            TearDown(entity, ctx);
        }
    }
}