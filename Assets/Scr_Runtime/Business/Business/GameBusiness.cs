using System;
using UnityEngine;
using HNY;

public static class GameBusiness
{
    public static void Enter(GameContext ctx)
    {
        ParentEntity parentEntity = ParentDomain.Spawn(ctx);
        Transform parent = parentEntity.transform;
        Color color = ParentDomain.SetColor(parentEntity);

        FireworkEntity fireworkEntity = FireworkDomain.Spawn(ctx, parent);
        FireworkDomain.SetColor(fireworkEntity, color);

        TileEntity tileEntity = TileDomain.Spawn(ctx, parent);
        TileDomain.SetColor(tileEntity, color);

        BoomEntity boomEntity = BoomDomain.Spawn(ctx, parent);
        BoomDomain.SetColor(boomEntity, color);
    }

    public static void Tick(GameContext ctx, float dt)
    {
        PreTick(ctx);

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

        LastTick(ctx);
    }

    //预处理
    public static void PreTick(GameContext ctx)
    {
        int lenBoom = ctx.boomRepository.TakeAll(out BoomEntity[] booms);
        for(int i = 0; i < lenBoom; i++)
        {
            BoomEntity boom = booms[i];
            boom.gameObject.SetActive(false);
        }
    }

    //每restFixTime检测
    //用bool？太乱了（在哪加，何时用）
    public static void LogicTick(GameContext ctx, float dt)
    {

        int length = ctx.parentRepository.TakeAll(out ParentEntity[] parents);
        ctx.fireworkRepository.TakeAll(out FireworkEntity[] fireworks);
        ctx.tileRepository.TakeAll(out TileEntity[] tiles);
        ctx.boomRepository.TakeAll(out BoomEntity[] booms);

        for(int i = 0; i < length; i++)
        {
            ParentEntity parent = parents[i];
            FireworkEntity firework = fireworks[i];
            TileEntity tile = tiles[i];
            BoomEntity boom = booms[i];

            if(parent.transform.position.y < parent.beforePos.y + parent.size * 15)
            {
                ParentDomain.Move(parent);

                FireworkDomain.SetScale(firework, dt);
                TileDomain.SetScale(tile, dt);
            }
            // Debug.Log(parent.beforePos.y);

            else
            {
                ParentDomain.Stop(parent);

                firework.gameObject.SetActive(false);
                tile.gameObject.SetActive(false);

                boom.gameObject.SetActive(true);
                if(boom.transform.localScale.x < 10)
                {
                    BoomDomain.SetScale(boom, dt);
                }
                else
                {
                    BoomDomain.Stop(boom);
                }
            }
        }
    }

    //收尾（内存释放？）
    public static void LastTick(GameContext ctx)
    {
        
    }
}