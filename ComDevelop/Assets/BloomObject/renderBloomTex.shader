// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/renderBloomTex" {//modified from "Unlit/Color"
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
}
SubShader { //this subShader is same with "Unlit/Color" shader, except the RenderType change to "GroupBloom"
    Tags { "RenderType"="GroupBloom" }
    LOD 100
    Pass {  
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
            };
            struct v2f {
                float4 vertex : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };


            fixed4 _Color;
            
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            
            fixed4 frag (v2f i) : COLOR
            {
                fixed4 col = _Color;
                UNITY_APPLY_FOG(i.fogCoord, col);
                UNITY_OPAQUE_ALPHA(col.a);
                return col;
            }
        ENDCG
    }
}
SubShader { //because this subShader renders pure black, so we need not support fog
    Tags { "RenderType"="Opaque" }
    LOD 100
    
    Pass {  
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }
            
            fixed4 frag (v2f i) : COLOR
            {
                fixed4 col = float4(0,0,0,1);
                return col;
            }
        ENDCG
    }
}
}