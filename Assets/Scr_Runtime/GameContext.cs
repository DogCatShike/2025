using System;
using UnityEngine;
using HNY;

public class GameContext
{
    public IDService idService;
    public GameEntity gameEntity;

    //core
    public AssetsCore assetsCore;
    public InputCore inputCore;

    //repos
    public ParentRepository parentRepository;
    public FireworkRepository fireworkRepository;

    public GameContext()
    {
        idService = new IDService();
        gameEntity = new GameEntity();

        assetsCore = new AssetsCore();
        inputCore = new InputCore();

        parentRepository = new ParentRepository();
        fireworkRepository = new FireworkRepository();
    }

}