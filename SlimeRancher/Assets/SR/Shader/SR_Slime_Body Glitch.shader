//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "SR/Slime/Body Glitch" {
Properties {
_Cutoff ("Mask Clip Value", Float) = 0.3
_Grid ("Grid", Cube) = "black" { }
_TopColor ("Top Color", Color) = (0.04650232,0.1318716,0.1792453,0)
_BottomColor ("Bottom Color", Color) = (0.04650232,0.1318716,0.1792453,0)
_MiddleColor ("Middle Color", Color) = (0.2282841,0.4201993,0.509434,0)
_Noise ("Noise", 2D) = "white" { }
_NoiseTiles ("Noise Tiles", Float) = 6
_NoiseSpeed ("Noise Speed", Float) = 4
_Mask ("Mask", 2D) = "white" { }
[Toggle] _ToggleMask ("Toggle Mask", Float) = 0
_Pixels ("Pixels", 2D) = "black" { }
_GridMultiply ("Grid Multiply", Float) = 1
_GlitchAmount ("GlitchAmount", Float) = 0
_Alpha ("Alpha", Range(0, 1)) = 1
[Toggle] _ToggleFresnel ("Toggle Fresnel", Float) = 1
_texcoord ("", 2D) = "white" { }
__dirty ("", Float) = 1
}
SubShader {
 Tags { "IsEmissive" = "true" "QUEUE" = "AlphaTest+0" "RenderType" = "TransparentCutout" }
 GrabPass {
  "_RefractionAlphaClip"
}
 Pass {
  Name "FORWARD"
  Tags { "IsEmissive" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "AlphaTest+0" "RenderType" = "TransparentCutout" }
  GpuProgramID 59391
Program "vp" {
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" }
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
}
CustomEditor "ASEMaterialInspector"
}