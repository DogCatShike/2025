using System;
using UnityEngine;
using HNY;

public static class GameBusiness
{
    public static void Enter(GameContext ctx, Transform parent)
    {
        FireworkDomain.Spawn(ctx, 1, parent);
    }
}