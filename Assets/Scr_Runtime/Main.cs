using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            bool isKey = ctx.inputCore.GetKeyDown();
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