// 
// normal.vs
//
//      Pass through vertex shader.
//
// Copyright (c) 2009 Dan Gudmundsson
//
//  See the file "license.terms" for information on usage and redistribution
//  of this file, and for a DISCLAIMER OF ALL WARRANTIES.
//
 
varying vec3 w3d_normal;
uniform vec2 auv_texsz;

varying vec2 w3d_uv;
varying vec4 w3d_tangent;

void main(void)
{
    w3d_uv    = gl_Vertex.xy;

    w3d_normal  = gl_Normal.xyz;
    w3d_tangent = gl_MultiTexCoord2;
    
    vec4 Position = gl_Vertex;
    gl_Position   = (gl_ModelViewProjectionMatrix * Position);
}
