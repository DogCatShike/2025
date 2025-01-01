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
    public BoomRepository boomRepository;
    public TileRepository tileRepository;
    public HeadRepository headRepository;

    public GameContext()
    {
        idService = new IDService();
        gameEntity = new GameEntity();

        assetsCore = new AssetsCore();
        inputCore = new InputCore();

        parentRepository = new ParentRepository();
        fireworkRepository = new FireworkRepository();
        boomRepository = new BoomRepository();
        tileRepository = new TileRepository();
        headRepository = new HeadRepository();
    }

}