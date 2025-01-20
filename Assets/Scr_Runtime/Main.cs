using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HNY
{
    public class Main : MonoBehaviour
    {
        GameContext ctx;

        void Awake()
        {
            ctx = new GameContext();

            ctx.assetsCore.LoadAll();
        }

        void Update()
        {
            ctx.inputCore.GetKey();
            bool isKey = ctx.inputCore.getKeyDown;
            float dt = Time.deltaTime;

            if(isKey)
            {
                GameBusiness.Enter(ctx);
                //TODO
            }

            GameBusiness.Tick(ctx, dt);
        }
    }
}