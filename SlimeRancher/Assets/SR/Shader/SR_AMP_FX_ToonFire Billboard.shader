//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "SR/AMP/FX/ToonFire Billboard" {
Properties {
[Toggle(_UNSCALEDTIME_ON)] _UnscaledTime ("Unscaled Time?", Float) = 0
_Cutoff ("Mask Clip Value", Float) = 0.5
_ColorOutside ("Color Outside", Color) = (1,0.02937273,0,1)
_ColorInside ("Color Inside", Color) = (1,0.6135118,0,1)
_OutsideContrast ("Outside Contrast", Range(0, 1)) = 0.75
_InsideContrast ("Inside Contrast", Range(0, 1)) = 0
_NoiseTexture ("Noise Texture", 2D) = "white" { }
_NoiseScale ("Noise Scale", Float) = 1
_NoisePanSpeed ("Noise Pan Speed", Vector) = (0.333,-1.2,-0.5,-1.06)
_DistortionSpeed ("Distortion Speed", Float) = 1
_DistortionScale ("Distortion Scale", Float) = 0.5
_PushForward ("Push Forward", Float) = 0.3
_DepthFade ("Depth Fade", Float) = 0.25
_RadialMaskTilingOffset ("RadialMask Tiling/Offset", Vector) = (1.5,1,-0.25,-0.21)
_texcoord ("", 2D) = "white" { }
__dirty ("", Float) = 1
}
SubShader {
 Tags { "DisableBatching" = "true" "FORCENOSHADOWCASTING" = "true" "IGNOREPROJECTOR" = "true" "IsEmissive" = "true" "QUEUE" = "AlphaTest+0" "RenderType" = "Transparent" }
 Pass {
  Name "FORWARD"
  Tags { "DisableBatching" = "true" "FORCENOSHADOWCASTING" = "true" "IGNOREPROJECTOR" = "true" "IsEmissive" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "AlphaTest+0" "RenderType" = "Transparent" }
  Blend One OneMinusSrcAlpha, OneMinusDstColor One
  ZWrite Off
  GpuProgramID 39127
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
Keywords { "DIRECTIONAL" "_UNSCALEDTIME_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" "_UNSCALEDTIME_ON" }
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "_UNSCALEDTIME_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" "_UNSCALEDTIME_ON" }
"// shader disassembly not supported on DXBC"
}
}
}
}
CustomEditor "ASEMaterialInspector"
}