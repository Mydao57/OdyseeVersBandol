// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader"Custom/BLUR" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
        _BumpAmt  ("Distortion", Range (0,128)) = 10
        _MainTex ("Tint Color (RGB)", 2D) = "white" {}
        _BumpMap ("Normalmap", 2D) = "bump" {}
        _Size ("Size", Range(0, 20)) = 1
        _BlurStrength("Blur Strength", Range(0.1, 5.0)) = 1.0
    }
 
    Category {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Opaque" }
 
        SubShader {
            GrabPass {                    
                Tags { "LightMode" = "Always" }
            }
            Pass {
                Tags { "LightMode" = "Always" }
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fastest
#include "UnityCG.cginc"
             
struct appdata_t
{
    float4 vertex : POSITION;
    float2 texcoord : TEXCOORD0;
};
             
struct v2f
{
    float4 vertex : POSITION;
    float4 uvgrab : TEXCOORD0;
};
             
v2f vert(appdata_t v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
#if UNITY_UV_STARTS_AT_TOP
                    float scale = -1.0;
#else
    float scale = 1.0;
#endif
    o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y * scale) + o.vertex.w) * 0.5;
    o.uvgrab.zw = o.vertex.zw;
    return o;
}
             
sampler2D _GrabTexture;
float4 _GrabTexture_TexelSize;
float _Size;
float _BlurStrength;
             
half4 frag(v2f i) : COLOR
{
    half4 sum = half4(0, 0, 0, 0);
#define GRABPIXEL(weight,kernelx) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x + _GrabTexture_TexelSize.x * kernelx*_Size * _BlurStrength, i.uvgrab.y, i.uvgrab.z, i.uvgrab.w))) * weight
    sum += GRABPIXEL(0.05, -4.0);
    sum += GRABPIXEL(0.09, -3.0);
    sum += GRABPIXEL(0.12, -2.0);
    sum += GRABPIXEL(0.15, -1.0);
    sum += GRABPIXEL(0.18, 0.0);
    sum += GRABPIXEL(0.15, +1.0);
    sum += GRABPIXEL(0.12, +2.0);
    sum += GRABPIXEL(0.09, +3.0);
    sum += GRABPIXEL(0.05, +4.0);
                 
    return sum;
}
                ENDCG
            }
        }
    }
}
