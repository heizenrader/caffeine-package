// Channel packer for the Material Optimizer — Caffeine-owned superset of
// MRTK's Hidden/ChannelPacker. All converters (Standard, URP/Lit,
// URP/SimpleLit, glTF metallic-roughness, glTF spec-gloss) use this shader.
//
// Per-channel inputs:
//   _<Name>Map           source texture (defaults "black"/"white"/"gray" per role)
//   _<Name>MapChannel    0=R, 1=G, 2=B, 3=A, 4=RGBAverage (luminance)
//   _<Name>Uniform       >=0: use this constant value INSTEAD of sampling
//   _<Name>Multiplier    multiplied with the sampled (not uniform) value
//   _<Name>Invert        0 or 1: when 1, output = 1 - value
//
// Output layout matches Graphics Tools/Standard's _ChannelMap:
//   R = metallic, G = occlusion, B = emission mask, A = smoothness
//
// The multiplier is what lets us bake source-shader factor sliders
// (Standard's _GlossMapScale, URP/Lit's _Smoothness, gltf's roughnessFactor)
// into the texture-present case. Without it, those multipliers were silently
// dropped because GT shadows _Smoothness with channel.a when _CHANNEL_MAP
// is on. The invert flag handles glTF's roughness→smoothness flip.
Shader "Hidden/CaffeineChannelPacker"
{
    Properties
    {
        _MetallicMap("Metallic Map", 2D) = "black" {}
        _MetallicMapChannel("Metallic Map Channel", Int) = 0
        _MetallicUniform("Metallic Uniform", Float) = -0.01
        _MetallicMultiplier("Metallic Multiplier", Float) = 1.0
        _MetallicInvert("Metallic Invert", Int) = 0

        _OcclusionMap("Occlusion Map", 2D) = "white" {}
        _OcclusionMapChannel("Occlusion Map Channel", Int) = 1
        _OcclusionUniform("Occlusion Uniform", Float) = -0.01
        _OcclusionMultiplier("Occlusion Multiplier", Float) = 1.0
        _OcclusionInvert("Occlusion Invert", Int) = 0

        _EmissionMap("Emission Map", 2D) = "black" {}
        _EmissionMapChannel("Emission Map Channel", Int) = 4
        _EmissionUniform("Emission Uniform", Float) = -0.01
        _EmissionMultiplier("Emission Multiplier", Float) = 1.0
        _EmissionInvert("Emission Invert", Int) = 0

        _SmoothnessMap("Smoothness Map", 2D) = "gray" {}
        _SmoothnessMapChannel("Smoothness Map Channel", Int) = 3
        _SmoothnessUniform("Smoothness Uniform", Float) = -0.01
        _SmoothnessMultiplier("Smoothness Multiplier", Float) = 1.0
        _SmoothnessInvert("Smoothness Invert", Int) = 0
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MetallicMap;
            int _MetallicMapChannel;
            float _MetallicUniform;
            float _MetallicMultiplier;
            int _MetallicInvert;
            sampler2D _OcclusionMap;
            int _OcclusionMapChannel;
            float _OcclusionUniform;
            float _OcclusionMultiplier;
            int _OcclusionInvert;
            sampler2D _EmissionMap;
            int _EmissionMapChannel;
            float _EmissionUniform;
            float _EmissionMultiplier;
            int _EmissionInvert;
            sampler2D _SmoothnessMap;
            int _SmoothnessMapChannel;
            float _SmoothnessUniform;
            float _SmoothnessMultiplier;
            int _SmoothnessInvert;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed ToGrayScale(fixed4 color)
            {
                return color.r * 0.21 + color.g * 0.71 + color.b * 0.08;
            }

            fixed Sample(fixed4 color, int channel, float uniformValue, float multiplier, int invert)
            {
                fixed v;
                if (uniformValue >= 0.0)
                {
                    // Uniform path: caller already baked the desired value into
                    // the scalar; do NOT multiply again.
                    v = uniformValue;
                }
                else if (channel == 4)
                {
                    v = ToGrayScale(color) * multiplier;
                }
                else
                {
                    v = color[channel] * multiplier;
                }
                return invert != 0 ? 1.0 - v : v;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 output;
                output.r = Sample(tex2D(_MetallicMap, i.uv),  _MetallicMapChannel,  _MetallicUniform,  _MetallicMultiplier,  _MetallicInvert);
                output.g = Sample(tex2D(_OcclusionMap, i.uv), _OcclusionMapChannel, _OcclusionUniform, _OcclusionMultiplier, _OcclusionInvert);
                output.b = Sample(tex2D(_EmissionMap, i.uv),  _EmissionMapChannel,  _EmissionUniform,  _EmissionMultiplier,  _EmissionInvert);
                output.a = Sample(tex2D(_SmoothnessMap, i.uv),_SmoothnessMapChannel,_SmoothnessUniform,_SmoothnessMultiplier,_SmoothnessInvert);
                return output;
            }

            ENDCG
        }
    }
}
