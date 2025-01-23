using HNY;
using System;
using UnityEngine;

public static class GameDomain
{
    public static void ClearAll(GameContext ctx)
    {
        AudioDomain.Clear(ctx);
        FireworkDomain.Clear(ctx);
        TileDomain.Clear(ctx);
        BoomDomain.Clear(ctx);
        HeadDomain.Clear(ctx);
        ParentDomain.Clear(ctx);
    }

    public static void GameOver(GameContext ctx)
    {
        ClearAll(ctx);
    }
}