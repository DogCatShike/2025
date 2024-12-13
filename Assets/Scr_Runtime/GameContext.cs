using System;
using UnityEngine;
using HNY;

public class GameContext
{
    public IDService idService;

    //core
    public AssetsCore assetsCore;
    public InputCore inputCore;

    //repos
    public FireworkRepository fireworkRepository;

    public GameContext()
    {
        idService = new IDService();

        assetsCore = new AssetsCore();
        inputCore = new InputCore();

        fireworkRepository = new FireworkRepository();
    }
}