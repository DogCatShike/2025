using System;
using UnityEngine;
using HNY;

public static class GameBusiness
{
    public static void Enter(GameContext ctx, int noteNumber)
    {
        AudioEntity audioEntity = AudioDomain.Spawn(ctx);
        AudioDomain.SetClip(audioEntity, noteNumber);
        AudioDomain.Play(audioEntity);

        ParentEntity parentEntity = ParentDomain.Spawn(ctx);
        Transform parent = parentEntity.transform;
        Color color = ParentDomain.SetColor(parentEntity);

        FireworkEntity fireworkEntity = FireworkDomain.Spawn(ctx, parent);
        FireworkDomain.SetColor(fireworkEntity, color);

        TileEntity tileEntity = TileDomain.Spawn(ctx, parent);
        TileDomain.SetColor(tileEntity, color);

        BoomEntity boomEntity = BoomDomain.Spawn(ctx, parent);
        BoomDomain.SetColor(boomEntity, color);

        HeadEntity headEntity = HeadDomain.Spawn(ctx, parent);
        HeadDomain.SetColor(headEntity, color);

        FootEntity footEntity = FootDomain.Spawn(ctx, parent);
        FootDomain.SetColor(footEntity, color);
        FootDomain.SetMisc(footEntity);
        FootDomain.SetLine(footEntity, color);
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
        ctx.headRepository.TakeAll(out HeadEntity[] heads);
        ctx.footRepository.TakeAll(out FootEntity[] foots);

        for(int i = 0; i < lenBoom; i++)
        {
            BoomEntity boom = booms[i];
            boom.gameObject.SetActive(false);

            HeadEntity head = heads[i];
            head.gameObject.SetActive(false);

            FootEntity foot = foots[i];
            foot.gameObject.SetActive(false);
        }
    }

    //每restFixTime检测
    //用bool？太乱了（在哪加，何时用）
    //移至GameDomain？
    public static void LogicTick(GameContext ctx, float dt)
    {

        int length = ctx.parentRepository.TakeAll(out ParentEntity[] parents);
        ctx.fireworkRepository.TakeAll(out FireworkEntity[] fireworks);
        ctx.tileRepository.TakeAll(out TileEntity[] tiles);
        ctx.boomRepository.TakeAll(out BoomEntity[] booms);
        ctx.headRepository.TakeAll(out HeadEntity[] heads);
        ctx.footRepository.TakeAll(out FootEntity[] foots);
        ctx.audioRepository.TakeAll(out AudioEntity[] audios);

        for(int i = 0; i < length; i++)
        {
            AudioEntity audio = audios[i];
            ParentEntity parent = parents[i];
            FireworkEntity firework = fireworks[i];
            TileEntity tile = tiles[i];
            BoomEntity boom = booms[i];
            HeadEntity head = heads[i];
            FootEntity foot = foots[i];

            #region 运行逻辑
            float size = parent.size;

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

                    head.gameObject.SetActive(true);
                    HeadDomain.Move(head, dt, size);
                }

                if(boom.alpha >= 0)
                {
                    BoomDomain.SetAlpha(boom, dt);
                }
                else
                {
                    boom.gameObject.SetActive(false);
                }

                if(!head.isMoving)
                {
                    bool isTileScale = HeadDomain.SetTileScale(head, dt);

                    foot.gameObject.SetActive(true);
                    bool isMoving = FootDomain.IsMoving(foot);
                    FootDomain.SetPos(foot, head);
                    FootDomain.Move(foot, dt, size);

                    if(isTileScale && !isMoving)
                    {
                        Debug.Log("Done");
                        HeadDomain.SetHeadAlpha(head, dt);
                        FootDomain.SetAlpha(foot, dt);
                        
                        if(head.alpha <= 0.1)
                        {
                            head.gameObject.SetActive(false);
                            foot.gameObject.SetActive(false);

                            parent.gameObject.SetActive(false);
                        }
                    }
                }
            }
            #endregion

            #region 清理内存
            if(parent.isActiveAndEnabled == false)
            {
                AudioDomain.TearDown(audio, ctx);
                FireworkDomain.TearDown(firework, ctx);
                TileDomain.TearDown(tile, ctx);
                BoomDomain.TearDown(boom, ctx);
                HeadDomain.TearDown(head, ctx);
                ParentDomain.TearDown(parent, ctx);
                FootDomain.TearDown(foot, ctx);
            }
            #endregion
        }
    }

    //收尾（内存释放？）
    //应该不是
    public static void LastTick(GameContext ctx)
    {
        
    }
}