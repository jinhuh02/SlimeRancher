//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Hidden/StylizedFog" {
Properties {
_MainTex ("Base (RGB)", 2D) = "black" { }
_MainRamp ("MainRamp", 2D) = "white" { }
_BlendRamp ("MainRamp", 2D) = "white" { }
_Blend ("Blend", Range(0, 1)) = 0
_NoiseTex ("NoiseTex", 2D) = "white" { }
_NoiseTiling ("_FogTiling", Vector) = (1,1,1,1)
_NoiseSpeed ("FogSpeed", Vector) = (0,0,0,0)
}
SubShader {
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog {
   Mode Off
  }
  GpuProgramID 20976
Program "vp" {
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_OFF" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_ON" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_ON" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_OFF" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_ON" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_ON" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_MULTIPLY" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_MULTIPLY" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_MULTIPLY" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_MULTIPLY" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_MULTIPLY" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_MULTIPLY" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_MULTIPLY" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_MULTIPLY" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_FOG_SCREEN" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_FOG_SCREEN" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_FOG_SCREEN" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_FOG_SCREEN" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_FOG_SCREEN" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_FOG_SCREEN" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_FOG_SCREEN" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_FOG_SCREEN" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_FOG_OVERLAY" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_FOG_OVERLAY" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_FOG_OVERLAY" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_FOG_OVERLAY" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_FOG_OVERLAY" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_FOG_OVERLAY" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_FOG_OVERLAY" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_FOG_OVERLAY" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_DODGE" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_DODGE" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_DODGE" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_DODGE" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_DODGE" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_DODGE" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_DODGE" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_DODGE" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_OFF" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_ON" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_ON" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND" "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_OFF" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_ON" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_ON" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_ADDITIVE" "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_MULTIPLY" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_MULTIPLY" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_MULTIPLY" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_MULTIPLY" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_MULTIPLY" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_MULTIPLY" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_MULTIPLY" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_MULTIPLY" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_FOG_SCREEN" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_FOG_SCREEN" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_FOG_SCREEN" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_FOG_SCREEN" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_FOG_SCREEN" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_FOG_SCREEN" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_FOG_SCREEN" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_FOG_SCREEN" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_FOG_OVERLAY" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_OFF" "_FOG_OVERLAY" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_FOG_OVERLAY" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_NOISE_ON" "_FOG_OVERLAY" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_FOG_OVERLAY" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_OFF" "_FOG_OVERLAY" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_FOG_OVERLAY" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_NOISE_ON" "_FOG_OVERLAY" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_DODGE" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_DODGE" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_DODGE" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_OFF" "_FOG_DODGE" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_DODGE" "_FOG_NOISE_OFF" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_DODGE" "_FOG_NOISE_OFF" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_DODGE" "_FOG_NOISE_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_FOG_BLEND_ON" "_FOG_DODGE" "_FOG_NOISE_ON" "_SKYBOX" }
"// shader disassembly not supported on DXBC"
}
}
}
}
}