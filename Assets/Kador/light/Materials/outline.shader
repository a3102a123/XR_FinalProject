// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/OutlineShader" {
    Properties {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _OutLineWidth("width", float) = 1.2//定義一個變數
    }
    SubShader {

        Pass
        {
            CGPROGRAM       
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex:POSITION;
                float2 uv:TEXCOORD0;
            };

            struct v2f
            {
                float2 uv :TEXCOORD0;
                float4 vertex:SV_POSITION;
            };


            float _OutLineWidth;//設定變數
            v2f vert(appdata v)
            {
                v2f o;
                //設定一下xy
                //v.vertex.xy *= 1.1;
                v.vertex.xy *= _OutLineWidth;//乘上變數
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) :SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                //return col;
                return fixed4(0, 0, 1, 1);
            }
            ENDCG
        }
        

        Pass
            {
                ZTest Always
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                float4 vertex:POSITION;
                float2 uv:TEXCOORD0;
            };

            struct v2f
            {
                float2 uv :TEXCOORD0;
                float4 vertex:SV_POSITION;
            };


            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) :SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                //return fixed4(0, 0, 1, 1);//返回藍色，因為再次渲染會把第一個顏色覆蓋掉
                return col;
            }
                ENDCG
            }
    } 
    FallBack "Diffuse"
}