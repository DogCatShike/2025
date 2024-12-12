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
}