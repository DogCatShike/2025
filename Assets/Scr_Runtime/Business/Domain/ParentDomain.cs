using System;
using UnityEngine;
using HNY;

public static class ParentDomain
{
    public static ParentEntity Spawn(GameContext ctx, int typeID)
    {
        ParentEntity entity = GameFactory.Parent_Create(ctx, typeID);
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
}