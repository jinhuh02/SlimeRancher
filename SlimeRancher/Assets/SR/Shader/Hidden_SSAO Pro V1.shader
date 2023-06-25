//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Hidden/SSAO Pro V1" {
Properties {
_MainTex ("", 2D) = "white" { }
}
SubShader {
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog {
   Mode Off
  }
  GpuProgramID 38231
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
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog {
   Mode Off
  }
  GpuProgramID 78566
Program "vp" {
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog {
   Mode Off
  }
  GpuProgramID 187636
Program "vp" {
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog {
   Mode Off
  }
  GpuProgramID 235406
Program "vp" {
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog {
   Mode Off
  }
  GpuProgramID 278697
Program "vp" {
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_VERY_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_LOW" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_MEDIUM" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_HIGH" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" "SAMPLES_ULTRA" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog {
   Mode Off
  }
  GpuProgramID 376711
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
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog {
   Mode Off
  }
  GpuProgramID 436409
Program "vp" {
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "HIGH_PRECISION_DEPTHMAP_OFF" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog {
   Mode Off
  }
  GpuProgramID 515225
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
}