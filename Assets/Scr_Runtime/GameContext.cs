using System;
using UnityEngine;
using HNY;

public class GameContext
{
    public IDService idService;

    //core
    public AssetsCore assetsCore;

    //repos
    public FireworkRepository fireworkRepository;

    public GameContext()
    {
        idService = new IDService();

        assetsCore = new AssetsCore();

        fireworkRepository = new FireworkRepository();
    }
}