Shader "Gamma2Linear"
{
	Properties{
		_MainTex ("Texture", 2D) = "white" {}

	}

	SubShader{
		Cull Off
		ZTest Always
		ZWrite Off
		
		Pass{
			CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag 
				#include "UnityCG.cginc"	
				
				sampler2D _MainTex;
				
				
				struct a2v {
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f {
					float4 pos : POSITION;
					float2 uv : TEXCOORD0;
				};

				v2f vert (a2v v){
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}		
							
				half4 frag (v2f i): SV_Target{
					fixed4 col = tex2D(_MainTex,i.uv);
					col = pow(col,2.2);
					return col;					
				}

			ENDCG
		} 

		
	}
}