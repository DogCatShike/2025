using System;
using UnityEditor;
using UnityEngine;

public static class FireworkDomain
{
    public static FireworkEntity Spawn(GameContext ctx)
    {
        GameObject fw = new GameObject("fw");

        FireworkEntity entity = GameFactory.CreateFirework(ctx, fw.transform);

        entity.SetParent(fw);

        ctx.fireworkRepository.Add(entity);

        return entity;
    }

    public static void UnSpawn(GameContext ctx, FireworkEntity entity)
    {
        ctx.fireworkRepository.Remove(entity);
        entity.Disappear();
    }
}