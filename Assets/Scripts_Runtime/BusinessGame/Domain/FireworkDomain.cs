using System;
using UnityEditor;
using UnityEngine;

public static class FireworkDomain
{
    public static FireworkEntity Spawn(GameContext ctx, Transform parent)
    {
        FireworkEntity entity = GameFactory.CreateFirework(ctx, parent);
        ctx.fireworkRepository.Add(entity);

        return entity;
    }

    public static void UnSpawn(GameContext ctx, FireworkEntity entity)
    {
        ctx.fireworkRepository.Remove(entity);
        entity.Disappear();
    }
}