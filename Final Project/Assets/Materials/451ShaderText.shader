// TEXTURE NOTE: The used textures are from a random website. I didn't
// see anything on usage policy, but here is the URL to the rock texture
// https://www.textures.com/download/3dscans0409/132998
Shader "Unlit/CustomShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // Own matrix
            float4x4    MyXformMat;
            fixed4      MyColor;

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;

                o.vertex = mul(MyXformMat, v.vertex);

                o.vertex = mul(UNITY_MATRIX_VP, o.vertex);

                // Texture
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                col += MyColor;

                return col;
            }
            ENDCG
        }
    }
}
