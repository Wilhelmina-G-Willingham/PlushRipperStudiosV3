Shader "Custom/AutoTextureColorOverlayShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OverlayColor ("Overlay Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        fixed4 _OverlayColor;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Sample the object's texture
            fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);

            // Blend the overlay color with the texture
            fixed4 blendedColor = lerp(tex, _OverlayColor, 0.5);

            // Set the output albedo to the blended color
            o.Albedo = blendedColor.rgb;

            // Preserve the normal map if it exists
            o.Normal = UnpackNormal(tex2D(_MainTex, IN.uv_MainTex));
        }
        ENDCG
    }
    FallBack "Diffuse"
}












