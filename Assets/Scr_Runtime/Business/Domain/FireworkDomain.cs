using System;
using UnityEngine;
using HNY;

public static class FireworkDomain
{
    public static FireworkEntity Spawn(GameContext ctx, int typeID, Transform parent)
    {
        FireworkEntity entity = GameFactory.Firework_Create(ctx, typeID, parent);
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
}