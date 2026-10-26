// Flat ID colour writer for the Course Readiness visibility scan. Renders every face (no culling) in exactly the
// colour handed in through a MaterialPropertyBlock vector, so the scan can read object IDs back from the frame.
Shader "Hidden/Caffeine/IdColor"
{
    Properties
    {
        _IdColor ("Id", Vector) = (0, 0, 0, 1)
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" "Queue" = "Geometry" }
        Cull Off
        ZWrite On
        ZTest LEqual
        Fog { Mode Off }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float4 _IdColor;

            struct v2f { float4 pos : SV_POSITION; };

            v2f vert(float4 vertex : POSITION)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(vertex);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return _IdColor;
            }
            ENDCG
        }
    }
    Fallback Off
}
