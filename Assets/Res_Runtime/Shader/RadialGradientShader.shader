Shader "Custom/RadialGradient"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Texture", 2D) = "white" {}
        _Transparency("Transparency", Range(0, 1)) = 1 // 添加透明度属性
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" } // 设置为透明类型
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha // 启用混合以支持透明度
        ZWrite Off // 不写入深度缓冲区

        //以下完全不懂
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            float _Transparency; // 获取透明度值

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // 计算从中心到当前像素的距离
                float dist = length(i.uv - 0.5);
                // 使用距离计算渐变值 (0到1)
                float gradient = smoothstep(0.5, 0.0, dist);

                // 输出颜色，中心为白色，向外渐变到指定颜色，并应用透明度
                fixed4 outputColor = lerp(_Color, fixed4(1, 1, 1, 1), gradient);
                outputColor.a *= _Transparency; // 应用透明度

                return outputColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"//不支持时使用着色器Diffuse
}
