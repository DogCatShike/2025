using System;
using UnityEngine;
using HNY;
using System.Reflection;

public static class ParentDomain
{
    public static ParentEntity Spawn(GameContext ctx)
    {
        ParentEntity entity = GameFactory.Parent_Create(ctx);
        ctx.parentRepository.Add(entity);
        return entity;
    }

    public static Color SetColor(ParentEntity parent)
    {
        return parent.SetColor();
    }

    public static void Move(ParentEntity parent)
    {
        parent.Move();
    }

    public static void Stop(ParentEntity parent)
    {
        parent.Stop();
    }

    public static void TearDown(ParentEntity parent)
    {
        parent.TearDown();
    }
}