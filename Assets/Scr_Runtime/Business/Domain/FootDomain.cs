using System;
using UnityEngine;
using HNY;

public static class FootDomain
{
    public static FootEntity Spawn(GameContext ctx, Transform parent)
    {
        FootEntity entity = GameFactory.Foot_Create(ctx, parent);
        ctx.footRepository.Add(entity);
        return entity;
    }

    public static void SetColor(FootEntity foot, Color color)
    {
        foot.SetColor(color);
    }

    public static void SetAlpha(FootEntity foot, float dt)
    {
        foot.SetAlpha(dt);
    }

    public static void SetPos(FootEntity foot, HeadEntity head)
    {
        foot.SetPos(head);
    }

    public static void SetMisc(FootEntity foot)
    {
        foot.SetMisc();
    }

    public static void SetLine(FootEntity foot, Color color)
    {
        foot.SetLine(color);
    }

    public static void Move(FootEntity foot, float dt, float size)
    {
        foot.Move(dt, size);
    }

    public static bool IsMoving(FootEntity foot)
    {
        bool isMoving = foot.IsMoving();
        return isMoving;
    }

    public static void TearDown(FootEntity foot, GameContext ctx)
    {
        ctx.footRepository.Remove(foot);
        foot.TearDown();
    }

    public static void Clear(GameContext ctx)
    {
        int len = ctx.footRepository.TakeAll(out FootEntity[] entities);
        for (int i = 0; i < len; i++)
        {
            FootEntity entity = entities[i];
            TearDown(entity, ctx);
        }
    }
}