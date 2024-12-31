using System;
using UnityEngine;
using HNY;

public static class FireworkDomain
{
    public static FireworkEntity Spawn(GameContext ctx, Transform parent)
    {
        FireworkEntity entity = GameFactory.Firework_Create(ctx, parent);
        ctx.fireworkRepository.Add(entity);
        return entity;
    }

    #region 删除
    // public static void Move(FireworkEntity firework)
    // {
    //     firework.Move();
    // }
    #endregion

    public static void SetColor(FireworkEntity firework, Color color)
    {
        firework.SetColor(color);
    }

    public static void SetScale(FireworkEntity firework, float dt)
    {
        firework.SetScale(dt);
    }

    public static void TearDown(FireworkEntity firework, GameContext ctx)
    {
        ctx.fireworkRepository.Remove(firework);
        firework.TearDown();
    }

    public static void Clear(GameContext ctx)
    {
        int len = ctx.fireworkRepository.TakeAll(out FireworkEntity[] entities);
        for (int i = 0; i < len; i++)
        {
            FireworkEntity entity = entities[i];
            TearDown(entity, ctx);
        }
    }
}