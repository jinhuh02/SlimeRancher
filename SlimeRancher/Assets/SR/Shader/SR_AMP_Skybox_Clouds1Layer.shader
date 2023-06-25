//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "SR/AMP/Skybox/Clouds1Layer" {
Properties {
_Cutoff ("Mask Clip Value", Float) = 0.5
_NoiseTexture ("Noise Texture", 2D) = "white" { }
_NoiseTextureScale ("Noise Texture Scale", Float) = 1
_NoiseTextureScale2 ("Noise Texture Scale 2", Float) = 1
_NoiseScaleMaster ("Noise Scale Master", Float) = 1
_CloudSpeed1 ("Cloud Speed 1", Float) = 0
_CloudSpeed2 ("Cloud Speed 2", Float) = 0
_CloudSpeedMaster ("Cloud Speed Master", Float) = 1
_LightingOffsetDistance ("Lighting Offset Distance", Range(0, 15)) = 1
_Coverage ("Coverage", Range(0, 1)) = 0.5106499
_Softness ("Softness", Range(0, 1)) = 0.5
_RimPower ("Rim Power", Float) = 3
_RimLightStrength ("Rim Light Strength", Float) = 1
_SSSRim ("SSS Rim", Range(0, 1)) = 0
_SSSBoost ("SSS Boost", Range(0, 1)) = 1
_SSSPower ("SSS Power", Float) = 0
_AroundSunBias ("Around Sun Bias", Range(0, 1)) = 0
_TopOffset ("Top Offset", Range(-1, 1)) = 1
_TopShadingOpacity ("Top Shading Opacity", Range(0, 1)) = 1
_TopDownOffset ("TopDown Offset", Range(-1, 1)) = 1
_TopDownShadingSoftness ("TopDown Shading Softness", Range(0, 1)) = 0
_TopDownShadingLevel ("TopDown Shading Level", Range(0, 1)) = 0
_TopDownShadingOpacity ("TopDown Shading Opacity", Range(0, 1)) = 1
_AlphaCut ("AlphaCut", Float) = 0.2
_EdgeBlend ("EdgeBlend", Range(0, 10)) = 2
_Alpha ("Alpha", Float) = 5
_Dayness ("Dayness", Range(0, 1)) = 1
_ShadingNight ("Shading - Night", Color) = (0.007843138,0.007843138,0.1686275,0)
_BaseColorNight ("BaseColor - Night", Color) = (0.02745098,0.1294118,0.3411765,0.5019608)
_BaseColor ("BaseColor", Color) = (0.9176471,0.9725491,1,1)
_Shading ("Shading", Color) = (0.1803922,0.5882353,0.7882354,0.2392157)
__dirty ("", Float) = 1
}
SubShader {
 Tags { "IGNOREPROJECTOR" = "true" "IsEmissive" = "true" "QUEUE" = "Transparent+0" "RenderType" = "Custom" }
 Pass {
  Name "FORWARD"
  Tags { "IGNOREPROJECTOR" = "true" "IsEmissive" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent+0" "RenderType" = "Custom" }
  Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
  Cull Off
  GpuProgramID 40261
Program "vp" {
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "VERTEXLIGHT_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" "VERTEXLIGHT_ON" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "FORWARD"
  Tags { "IGNOREPROJECTOR" = "true" "IsEmissive" = "true" "LIGHTMODE" = "FORWARDADD" "QUEUE" = "Transparent+0" "RenderType" = "Custom" }
  Blend One One, One One
  ZWrite Off
  Cull Off
  GpuProgramID 78111
Program "vp" {
SubProgram "d3d11 " {
Keywords { "POINT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "SPOT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
Keywords { "POINT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "SPOT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" }
"// shader disassembly not supported on DXBC"
}
}
}
}
CustomEditor "ASEMaterialInspector"
}