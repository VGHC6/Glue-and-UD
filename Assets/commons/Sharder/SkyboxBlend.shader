Shader "Custom/SkyboxBlend"
{
    Properties
    {
        _Skybox1 ("Day Skybox", Cube) = "white" {}
        _Skybox2 ("Night Skybox", Cube) = "white" {}
        _Blend ("Blend", Range(0, 1)) = 0
        _Exposure ("Exposure", Range(0, 8)) = 1
        _Rotation ("Rotation", Range(0, 360)) = 0
    }
    
    SubShader
    {
        Tags { "Queue"="Background" "RenderType"="Background" "PreviewType"="Skybox" }
        Cull Off 
        ZWrite Off
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            samplerCUBE _Skybox1;
            samplerCUBE _Skybox2;
            float _Blend;
            float _Exposure;
            float _Rotation;
            
            struct appdata
            {
                float4 vertex : POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            
            struct v2f
            {
                float3 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
                UNITY_VERTEX_OUTPUT_STEREO
            };
            
            float3 RotateAroundYInDegrees(float3 vertex, float degrees)
            {
                float alpha = degrees * UNITY_PI / 180.0;
                float sina, cosa;
                sincos(alpha, sina, cosa);
                float2x2 m = float2x2(cosa, -sina, sina, cosa);
                return float3(mul(m, vertex.xz), vertex.y).xzy;
            }
            
            v2f vert (appdata v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                
                float3 rotated = RotateAroundYInDegrees(v.vertex.xyz, _Rotation);
                o.vertex = UnityObjectToClipPos(rotated);
                o.texcoord = v.vertex.xyz;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float3 dir = normalize(i.texcoord);
                
                // Sample both skyboxes
                fixed4 col1 = texCUBE(_Skybox1, dir);
                fixed4 col2 = texCUBE(_Skybox2, dir);
                
                // Blend between them
                fixed4 col = lerp(col1, col2, _Blend);
                
                // Apply exposure
                col.rgb *= _Exposure;
                
                return col;
            }
            ENDCG
        }
    }
}