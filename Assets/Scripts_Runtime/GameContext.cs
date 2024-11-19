using System;
using UnityEngine;

public class GameContext
{
    public FireworkEntity fireworkEntity;
    
    public FireworkRepository fireworkRepository;

    public GameContext()
    {
        fireworkRepository = new FireworkRepository();
    }
}