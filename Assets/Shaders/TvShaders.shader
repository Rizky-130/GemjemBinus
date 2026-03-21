    Shader "Custom/CRTStatic"
    {
        Properties
        {
            _MainTex ("Texture", 2D) = "transparent" {}
            _NoiseIntensity ("Noise Intensity", Range(0,1)) = 0.3
            _Distortion ("Distortion", Range(0,0.1)) = 0.02
            _ScanlineStrength ("Scanline Strength", Range(0,1)) = 0.2
            _GlitchStrength ("Glitch Strength", Range(0,1)) = 0.5
        }

        SubShader
        {
            Tags { "RenderType"="Opaque" }  

            Pass
            {
                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                sampler2D _MainTex;
                float4 _MainTex_TexelSize;

                float _NoiseIntensity;
                float _Distortion;
                float _ScanlineStrength;
                float _GlitchStrength;

                float _TimeY;

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

                float rand(float2 co)
                {
                    return frac(sin(dot(co, float2(12.9898,78.233))) * 43758.5453);
                }

                v2f vert (appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag (v2f i) : SV_Target
                {
                    float2 uv = i.uv;

                    // --- Horizontal distortion (wavy CRT effect)
                    float wave = sin(uv.y * 80 + _Time.y * 5) * _Distortion;
                    uv.x += wave;

                    // --- Glitch bands
                    float glitch = step(0.95, rand(float2(_Time.y, uv.y)));
                    uv.x += glitch * (_GlitchStrength * (rand(float2(uv.y, _Time.y)) - 0.5));

                    // --- Sample base image
                    fixed4 col = tex2D(_MainTex, uv);

                    // --- Scanlines
                    float scan = sin(uv.y * 800) * 0.5 + 0.5;
                    col.rgb *= lerp(1.0, scan, _ScanlineStrength);

                    // --- Static noise
                    float noise = rand(uv * _Time.y * 50);
                    col.rgb += noise * _NoiseIntensity;

                    // --- Slight RGB offset (chromatic aberration)
                    float offset = 0.002;
                    float r = tex2D(_MainTex, uv + float2(offset,0)).r;
                    float g = tex2D(_MainTex, uv).g;
                    float b = tex2D(_MainTex, uv - float2(offset,0)).b;

                    col.rgb = float3(r,g,b);

                    return col;
                }
                ENDHLSL
            }
        }
    }