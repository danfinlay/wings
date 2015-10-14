//
//  normal.fs --
//
//     Simple object normal shader
//
//  Copyright (c) 2009 Dan Gudmundsson
//
//  See the file "license.terms" for information on usage and redistribution
//  of this file, and for a DISCLAIMER OF ALL WARRANTIES.
//

varying vec3 w3d_normal;
varying vec4 w3d_tangent;
uniform float w3d_tangentspace;
varying vec2 w3d_uv;
uniform sampler2D normalmap;

void main(void)
{
   vec3 color;
   if(w3d_tangentspace < 0.1) {
       // Scale normals range from: -1,1 to 0,1
       color = (normalize(w3d_normal)+1.0)*0.5;
       gl_FragColor = vec4(color, 1.0);
       return;
   }
   vec3 T = normalize(w3d_tangent.xyz);
   vec3 N = normalize(w3d_normal.xyz);
   T = normalize(T - dot(T, N) * N);
   vec3 B = cross(T, N) * w3d_tangent.w;
   mat3 InvTBN = transpose(mat3(T, B, N));

   vec3 HighResNormal = texture2D(normalmap, w3d_uv.xy).xyz;
   vec3 NewNormal = 2.0 * HighResNormal - vec3(1.0, 1.0, 1.0);
   NewNormal = InvTBN * NewNormal;
   color = normalize(NewNormal);
   //color =  w3d_tangent.xyz-w3d_normal.xyz;
   color = (color+1.0)*0.5;
   gl_FragColor = vec4(color, 1.0);
}

