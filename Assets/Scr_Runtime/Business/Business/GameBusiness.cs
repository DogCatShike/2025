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

    public static void Tick(GameContext ctx, float dt)
    {
        PreTick(ctx, dt);

        ref float restFixTime = ref ctx.gameEntity.restFixTime;

        restFixTime += dt;
        const float FIX_INTERVAL = 0.020f;

        if (restFixTime <= FIX_INTERVAL) 
        {
            LogicTick(ctx, restFixTime);
            restFixTime = 0;
        }
        else
        {
            while (restFixTime >= FIX_INTERVAL)
            {
                LogicTick(ctx, FIX_INTERVAL);
                restFixTime -= FIX_INTERVAL;
            }
        }

        LastTick(ctx, dt);
    }

    //预处理
    public static void PreTick(GameContext ctx, float dt)
    {

    }

    //每restFixTime检测
    public static void LogicTick(GameContext ctx, float dt)
    {
        ParentEntity parentEntity = ctx.GetParent();

        ParentDomain.Move(parentEntity);
    }

    //收尾（内存释放？）
    public static void LastTick(GameContext ctx, float dt)
    {

    }
}