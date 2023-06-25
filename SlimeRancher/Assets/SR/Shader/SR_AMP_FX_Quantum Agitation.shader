//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "SR/AMP/FX/Quantum Agitation" {
Properties {
_MainTexture ("Main Texture", 2D) = "black" { }
_SmokeColor ("Smoke Color", Color) = (1,1,1,1)
_BitsColor ("Bits Color", Color) = (1,1,1,1)
_OrbitsColorA ("Orbits Color A", Color) = (1,1,1,1)
_OrbitsColorB ("Orbits Color B", Color) = (1,1,1,1)
_DepthFade ("Depth Fade", Float) = 0.25
_texcoord ("", 2D) = "white" { }
__dirty ("", Float) = 1
}
SubShader {
 Tags { "DisableBatching" = "true" "IGNOREPROJECTOR" = "true" "IsEmissive" = "true" "QUEUE" = "Transparent+0" "RenderType" = "Custom" }
 Pass {
  Name "FORWARD"
  Tags { "DisableBatching" = "true" "IGNOREPROJECTOR" = "true" "IsEmissive" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent+0" "RenderType" = "Custom" }
  Blend One One, SrcAlpha OneMinusSrcAlpha
  ZWrite Off
  GpuProgramID 15743
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