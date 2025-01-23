using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HNY
{
    public class Main : MonoBehaviour
    {
        GameContext ctx;
        AudioEntity au;

        bool hasFirework;

        void Awake()
        {
            ctx = new GameContext();
            hasFirework = false;

            ctx.assetsCore.LoadAll();
        }

        void Update()
        {
            int noteNumber = ctx.inputCore.GetKey();
            bool isKey = ctx.inputCore.getKeyDown;
            float dt = Time.deltaTime;

            if(isKey && !hasFirework)
            {
                GameBusiness.Enter(ctx, noteNumber);
                hasFirework = true;
                //TODO
            }
            else if(!isKey)
            {
                hasFirework = false;
            }

            GameBusiness.Tick(ctx, dt);
        }
    }
}