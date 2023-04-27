Shader "Custom/Hint Shader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        [HDR] _Color ("Main Color", Color) = (1, 1, 1, 1)
        _RimColor ("Rim Color", Color) = (1, 0.92, 0.016, 1)
        _RimPower ("Rim Power", Range(0, 10)) = 3
        _ScrollDirection ("Scroll Direction", Vector) = (0, 0, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "IgnoreProjector"="True" "Queue"="Transparent" }
        LOD 100
        Cull Back
        Lighting Off
        ZWrite On
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #ifndef SHADER_API_D3D11
                #pragma target 3.0
            #else
                #pragma target 4.0
            #endif

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float rim : TEXCOORD1;
                float4 position : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            fixed4 _Color;
            fixed4 _RimColor;
            half _RimPower;
            float4 _ScrollDirection;

            v2f vert (appdata v)
            {
                v2f o;
                o.position = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                float rim = 1.0 - saturate(dot(normalize(v.normal), normalize(_WorldSpaceCameraPos - mul(unity_ObjectToWorld, v.vertex))));
                o.rim = pow(rim, _RimPower);
                o.uv += _ScrollDirection.xy * _Time.y;
                return o;
            }

            half4 col;
            fixed4 frag (v2f i) : SV_Target
            {
                col = tex2D(_MainTex, i.uv) * _Color;
                col.rgb = lerp(_RimColor.rgb, col.rgb, i.rim);
                col.a = 1;
                
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}