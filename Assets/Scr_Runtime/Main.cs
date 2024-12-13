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

            if(isKey)
            {
                Transform parent = new GameObject("f").transform;
                GameBusiness.Enter(ctx, parent);
                int fireworkLen = ctx.fireworkRepository.TakeAll(out FireworkEntity[] fireworks);
                for (int i = 0; i < fireworkLen; i++) {
                    FireworkEntity firework = fireworks[i];
                    FireworkDomain.Move(firework);
                }
            }
        }
    }
}