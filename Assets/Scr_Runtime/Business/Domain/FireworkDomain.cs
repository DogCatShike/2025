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

    public static void TearDown(FireworkEntity firework)
    {
        firework.TearDown();
    }
}