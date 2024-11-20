using System;
using UnityEngine;

public class GameContext
{
    public FireworkRepository fireworkRepository;
    public AssetsCore assetsCore;

    public GameContext()
    {
        //repo
        fireworkRepository = new FireworkRepository();

        //core
        assetsCore = new AssetsCore();
    }
}