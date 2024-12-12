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
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Transform parent = new GameObject().transform;
                GameBusiness.Enter(ctx, parent);
            }
        }
    }
}