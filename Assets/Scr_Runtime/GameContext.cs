using System;
using UnityEngine;
using HNY;

public class GameContext
{
    //core
    public AssetsCore assetsCore;

    //repos
    public FireworkRepository fireworkRepository;

    public GameContext()
    {
        assetsCore = new AssetsCore();

        fireworkRepository = new FireworkRepository();
    }
}