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
                GameBusiness.Enter(ctx);
                
                int parentLen = ctx.parentRepository.TakeAll(out ParentEntity[] parents);

                //TODO
            }
        }
    }
}