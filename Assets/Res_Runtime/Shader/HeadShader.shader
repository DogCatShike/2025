Shader "Custom/HeadShader"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Texture", 2D) = "white" {}
        _Transparency("Transparency", Range(0, 1)) = 0.8
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

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
            float _Transparency;
            float _HeadTransparency;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float dist = length(i.uv - 0.5);
                float gradient = smoothstep(0.7, 0.0, dist);

                fixed4 outputColor = lerp(_Color, fixed4(1, 1, 1, 1), gradient);
                outputColor.a *= _Transparency;

                return outputColor;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
