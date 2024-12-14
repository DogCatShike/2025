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
                //parent没地方存
                //放其他里面不合适，在想要不要新建个Entity，顺便把移动放parent？就不用一直传递transform了
                //下回改，好懒
                Transform parent = new GameObject("f").transform;
                GameBusiness.Enter(ctx, parent);
                int fireworkLen = ctx.fireworkRepository.TakeAll(out FireworkEntity[] fireworks);

                for (int i = 0; i < fireworkLen; i++) 
                {
                    FireworkEntity firework = fireworks[i];

                    FireworkDomain.Move(firework);
                }
            }
        }
    }
}