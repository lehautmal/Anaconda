Shader "SwoOop/ShaderAnaconda"
{
	Properties 
	{
_DiffuseColor("_DiffuseColor", Color) = (1,0.7647059,0.1470588,1)
_TexMat1("_TexMat1", 2D) = "black" {}
_TexMat2("_TexMat2", 2D) = "black" {}
_RimColor("_RimColor", Color) = (0.8014706,0,0,1)
_RimPower("_RimPower", Range(0.1,5) ) = 1.79
_Glossiness("_Glossiness", Range(0.1,1) ) = 0.4300518
_SpecularColor("_SpecularColor", Color) = (1,0.9851927,0.4632353,1)
_AlphaOpacity("_AlphaOpacity", 2D) = "black" {}
_SpecMap("_SpecMap", 2D) = "black" {}
_Blend("_Blend", Range(0,1) ) = 0
_RimAlpha("rim alpha", Range(0,8) ) = 4.16
_Sizecutoutmask("_Sizecutoutmask", Range(0,1) ) = 0.193

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Geometry-1"
"IgnoreProjector"="False"
"RenderType"="TransparentCutout"

		}

		
Cull Back
ZWrite On
ZTest LEqual
ColorMask RGBA
Blend SrcAlpha OneMinusSrcAlpha
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  vertex:vert
#pragma target 2.0


float4 _DiffuseColor;
sampler2D _TexMat1;
sampler2D _TexMat2;
float4 _RimColor;
float _RimPower;
float _Glossiness;
float4 _SpecularColor;
sampler2D _AlphaOpacity;
sampler2D _SpecMap;
float _Blend;
float _RimAlpha;
float _Sizecutoutmask;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
half3 spec = light.a * s.Gloss;
half4 c;
c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
c.a = s.Alpha;
return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input {
				float2 uv_TexMat1;
float2 uv_TexMat2;
float3 viewDir;
float2 uv_SpecMap;

			};

			void vert (inout appdata_full v, out Input o) {
float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);


			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
float4 Tex2D3=tex2D(_TexMat1,(IN.uv_TexMat1.xyxy).xy);
float4 Tex2D2=tex2D(_TexMat2,(IN.uv_TexMat2.xyxy).xy);
float4 Lerp1=lerp(Tex2D3,Tex2D2,_Blend.xxxx);
float4 Multiply2=float4( 0.5,0.5,0.5,0.5 ) * float4( IN.viewDir.x, IN.viewDir.y,IN.viewDir.z,1.0 );
float4 Invert1= float4(1.0, 1.0, 1.0, 1.0) - Multiply2;
float4 Lerp2_1_NoInput = float4(0,0,0,0);
float4 Lerp2=lerp(Invert1,Lerp2_1_NoInput,float4( IN.viewDir.x, IN.viewDir.y,IN.viewDir.z,1.0 ));
float4 Fresnel0_1_NoInput = float4(0,0,1,1);
float4 Fresnel0=(1.0 - dot( normalize( Lerp2.xyz), normalize( Fresnel0_1_NoInput.xyz ) )).xxxx;
float4 Pow0=pow(Fresnel0,_RimPower.xxxx);
float4 Multiply0=_RimColor * Pow0;
float4 Tex2D0=tex2D(_SpecMap,(IN.uv_SpecMap.xyxy).xy);
float4 Lerp0=lerp(Tex2D0,_SpecularColor,_Blend.xxxx);
float4 Master0_1_NoInput = float4(0,0,1,1);
float4 Master0_5_NoInput = float4(1,1,1,1);
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Lerp1;
o.Emission = Multiply0;
o.Specular = _Glossiness.xxxx;
o.Gloss = Lerp0;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}