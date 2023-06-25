//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "SR/AMP/FX/ScreenSpace Overlay TextureAlpha" {
Properties {
_MainTexture ("MainTexture", 2D) = "black" { }
_Color ("Color", Color) = (1,1,1,0.5019608)
}
SubShader {
 LOD 100
 Tags { "Overlay" = "Overlay" "RenderType" = "Opaque" }
 Pass {
  Name "Unlit"
  LOD 100
  Tags { "Overlay" = "Overlay" "RenderType" = "Opaque" }
  Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
  AlphaToMask On
  ZTest Always
  ZWrite Off
  GpuProgramID 57384
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