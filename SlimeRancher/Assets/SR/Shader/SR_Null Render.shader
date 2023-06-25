//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "SR/Null Render" {
Properties {
}
SubShader {
 Pass {
  GpuProgramID 121555
}
}
SubShader {
 Pass {
  GpuProgramID 51768
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