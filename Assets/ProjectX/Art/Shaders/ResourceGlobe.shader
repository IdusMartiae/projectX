Shader "UI/Unlit/ResourceGlobe"
{
    Properties
    {
        _Health("Health", Range(0, 1)) = 1
        _ShadowRadius("Shadow Radius", Range(0, 1)) = 0
        
        [NoScaleOffset] _TopTexture("Top layer texture", 2D) = "white" {}
        _TopScale("Scale", float) = 1
        _TopSpeed("Speed", float) = 1
        _TopMainColor("Main color", Color) = (1,1,1,1)
        
        [NoScaleOffset] _BottomTexture("Bottom layer texture", 2D) = "white" {}
        _BottomScale("Scale", float) = 1
        _BottomSpeed("Speed ", float) = 1
        _BottomMainColor("Main Color", Color) = (1,1,1,1)
        _BottomComplimentaryColor("Complimentary Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            Cull Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float _Health;
            float _ShadowRadius;
            
            sampler2D _TopTexture;
            float _TopScale;
            float _TopSpeed;
            float4 _TopMainColor;

            sampler2D _BottomTexture;
            float _BottomScale;
            float _BottomSpeed;
            float4 _BottomMainColor;
            float4 _BottomComplimentaryColor;
            
            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 wPos : TEXCOORD2;
            };
            
            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.wPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                // Circular mask
                float2 uvsCentered = i.uv * 2 - 1;
                float circleMask = distance(uvsCentered, float2(0, 0));
                float sdf = (circleMask - 0.8) * 5 - 3.26;
                
                float2 fisheyeProj = uvsCentered / sdf; // Apply barrel distortion
                
                clip(1 - circleMask); // Clip view in circular shape

                // Scroll texture over time
                float deltaX = - _Time.x;
                float deltaY = sin(_Time.x * 2) * 0.4 + _Time.x / 1.3;
                float2 offset = float2(deltaX, deltaY);
                
                float2 bottomUvs = fisheyeProj * _BottomScale + offset * _BottomSpeed;
                float4 bottomMask = tex2D(_BottomTexture, bottomUvs);
                
                float2 topUvs = fisheyeProj * _TopScale + offset * _TopSpeed;
                float4 topMask = tex2D(_TopTexture, topUvs);
                
                // Overlay top and bottom color layer to add depth
                float4 bottomColorLayer = lerp( _BottomComplimentaryColor, _BottomMainColor, bottomMask);
                float4 topColorLayer = lerp(bottomColorLayer, _TopMainColor, topMask);
                                
                // Clip resource bar based on remaining health
                float mask = _Health > i.uv.y;
                clip(mask-1);
                
                //float4 finalColor = lerp(layer, layer1, liquidMask1);
                
                return topColorLayer * (- circleMask  + (1.2 - _ShadowRadius));
            }
            ENDCG
        }
    }
}
