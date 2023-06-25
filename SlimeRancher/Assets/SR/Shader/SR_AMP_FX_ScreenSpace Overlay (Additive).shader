//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "SR/AMP/FX/ScreenSpace Overlay (Additive)" {
Properties {
_Color ("Color", Color) = (1,1,1,1)
_MainTexture ("Main Texture", 2D) = "white" { }
[Toggle] _RedUVsRadial ("Red UVs Radial", Float) = 0
_RedSpeedXYScaleZW ("Red Speed(X/Y) Scale(Z/W)", Vector) = (0,0,1,1)
[Toggle] _GreenUVsRadial ("Green UVs Radial", Float) = 1
_GreenSpeedXYScaleZW ("Green Speed(X/Y) Scale(Z/W)", Vector) = (0,0,1,1)
[Toggle] _BlueUVsRadial ("Blue UVs Radial", Float) = 1
_BlueSpeedXYScaleZW ("Blue Speed(X/Y) Scale(Z/W)", Vector) = (0,0,1,1)
_VerticalMaskMin ("VerticalMask Min", Range(0, 1)) = 0
_VerticalMaskMax ("VerticalMask Max", Range(0, 1)) = 0
_VerticalMaskTilingOffset ("VerticalMask Tiling/Offset", Vector) = (1,1,0,0)
_RadialMaskMin ("RadialMask Min", Range(0, 1)) = 0
_RadialMaskMax ("RadialMask Max", Range(0, 1)) = 0
_RadialMaskTilingOffset ("RadialMask Tiling/Offset", Vector) = (1,1,0,0)
_FinalMixOldMinMaxNewMinMax ("FinalMix Old(Min/Max) New(Min/Max)", Vector) = (0,1,0,1)
[Toggle] _EnableGradientMap ("Enable GradientMap", Float) = 0
_GradientMap ("GradientMap", 2D) = "white" { }
_texcoord ("", 2D) = "white" { }
}
SubShader {
 LOD 100
 Tags { "Overlay" = "Overlay" "RenderType" = "Opaque" }
 Pass {
  Name "Unlit"
  LOD 100
  Tags { "Overlay" = "Overlay" "RenderType" = "Opaque" }
  Blend One One, One One
  ZTest Always
  ZWrite Off
  GpuProgramID 9008
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
}
CustomEditor "ASEMaterialInspector"
}