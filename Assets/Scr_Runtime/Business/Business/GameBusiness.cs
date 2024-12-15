using System;
using UnityEngine;
using HNY;

public static class GameBusiness
{
    public static void Enter(GameContext ctx)
    {   
        ParentEntity parentEntity = ParentDomain.Spawn(ctx, 1);
        Transform parent = parentEntity.transform;
        Color color = ParentDomain.SetColor(parentEntity);
        
        FireworkEntity fireworkEntity = FireworkDomain.Spawn(ctx, 2, parent);
        FireworkDomain.SetColor(fireworkEntity, color);
    }
}