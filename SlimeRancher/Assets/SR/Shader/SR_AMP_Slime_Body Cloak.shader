//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "SR/AMP/Slime/Body Cloak" {
Properties {
_Cutoff ("Mask Clip Value", Float) = 0.5
_LightingUVHorizontalAdjust ("Lighting UV Horizontal Adjust", Range(0, 1)) = 0
_LightingUVContribution ("Lighting UV Contribution", Range(0, 1)) = 1
_TopColor ("Top Color", Color) = (1,0.7688679,0.7688679,1)
_MiddleColor ("Middle Color", Color) = (1,0.1556604,0.26705,1)
_BottomColor ("Bottom Color", Color) = (0.4716981,0,0.1533688,1)
_Gloss ("Gloss", Range(0, 2)) = 0
_GlossPower ("Gloss Power", Range(0, 1)) = 0.3
_BodyLightingContribution ("Body Lighting Contribution", Range(0, 1)) = 1
_Alpha ("Alpha", Range(0, 1)) = 0
_texcoord ("", 2D) = "white" { }
__dirty ("", Float) = 1
}
SubShader {
 Tags { "IsEmissive" = "true" "QUEUE" = "Overlay+1" "RenderType" = "TransparentCutout" }
 GrabPass {
  "_RefractionCloak"
}
 Pass {
  Name "FORWARD"
  Tags { "IsEmissive" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Overlay+1" "RenderType" = "TransparentCutout" }
  GpuProgramID 62995
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