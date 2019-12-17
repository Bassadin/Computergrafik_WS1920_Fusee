using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusee.Base.Core;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Serialization;

namespace FuseeApp
{
    public static class SimpleMeshes
    {
        public static Mesh CreateCuboid(float3 size)
        {
            return new Mesh
            {
                Vertices = new[]
                {
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = +0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z},
                    new float3 {x = +0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = +0.5f * size.z},
                    new float3 {x = -0.5f * size.x, y = -0.5f * size.y, z = -0.5f * size.z}
                },

                Triangles = new ushort[]
                {
                    // front face
                    0, 2, 1, 0, 3, 2,

                    // right face
                    4, 6, 5, 4, 7, 6,

                    // back face
                    8, 10, 9, 8, 11, 10,

                    // left face
                    12, 14, 13, 12, 15, 14,

                    // top face
                    16, 18, 17, 16, 19, 18,

                    // bottom face
                    20, 22, 21, 20, 23, 22

                },

                Normals = new[]
                {
                    new float3(0, 0, 1),
                    new float3(0, 0, 1),
                    new float3(0, 0, 1),
                    new float3(0, 0, 1),
                    new float3(1, 0, 0),
                    new float3(1, 0, 0),
                    new float3(1, 0, 0),
                    new float3(1, 0, 0),
                    new float3(0, 0, -1),
                    new float3(0, 0, -1),
                    new float3(0, 0, -1),
                    new float3(0, 0, -1),
                    new float3(-1, 0, 0),
                    new float3(-1, 0, 0),
                    new float3(-1, 0, 0),
                    new float3(-1, 0, 0),
                    new float3(0, 1, 0),
                    new float3(0, 1, 0),
                    new float3(0, 1, 0),
                    new float3(0, 1, 0),
                    new float3(0, -1, 0),
                    new float3(0, -1, 0),
                    new float3(0, -1, 0),
                    new float3(0, -1, 0)
                },

                UVs = new[]
                {
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0),
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0),
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0),
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0),
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0),
                    new float2(1, 0),
                    new float2(1, 1),
                    new float2(0, 1),
                    new float2(0, 0)
                },
                BoundingBox = new AABBf(-0.5f * size, 0.5f * size)
            };
        }

        public static ShaderEffect MakeShaderEffect(float3 diffuseColor, float3 specularColor, float shininess)
        {
            MaterialComponent temp = new MaterialComponent
            {
                Diffuse = new MatChannelContainer
                {
                    Color = new float4(diffuseColor, 1)
                },
                Specular = new SpecularChannelContainer
                {
                    Color = new float4(specularColor, 1),
                    Shininess = shininess
                }
            };

            return ShaderCodeBuilder.MakeShaderEffectFromMatComp(temp);
        }


        public static Mesh CreateCylinder(float radius, float height, int segmentsAmount)
        {
            float deltaSegmentAngle = 2 * (float)Math.PI / segmentsAmount;

            //Initialize all arrays
            float3[] verts = new float3[(4 * segmentsAmount) + 2];
            float3[] norms = new float3[verts.Length];
            ushort[] tris = new ushort[4 * 3 * segmentsAmount];


            //---------------------------------
            //--Create bottom circle segments--
            //---------------------------------

            //Circle Center
            //Top
            verts[4 * segmentsAmount] = new float3(0, height / 2, 0);
            norms[4 * segmentsAmount] = new float3(0, 1, 0);
            //Bottom
            verts[4 * segmentsAmount + 1] = new float3(0, -height / 2, 0);
            norms[4 * segmentsAmount + 1] = new float3(0, -1, 0);

            for (int i = 0; i < segmentsAmount; i++)
            {
                if (i < segmentsAmount)
                {

                    float3 radialNormal = new float3
                    {
                        x = (float)(Math.Cos(i * deltaSegmentAngle)),
                        y = 0,
                        z = (float)(Math.Sin(i * deltaSegmentAngle))
                    };

                    //Upper verts
                    float3 upperVert = new float3
                    {
                        x = (float)(radius * Math.Cos(i * deltaSegmentAngle)),
                        y = height / 2,
                        z = (float)(radius * Math.Sin(i * deltaSegmentAngle))
                    };
                    //Upper verts with top normal
                    verts[4 * i] = upperVert;
                    norms[4 * i] = new float3(0, 1, 0);

                    //Upper verts with radial normal
                    verts[(4 * i) + 1] = upperVert;
                    norms[(4 * i) + 1] = radialNormal;

                    //Lower verts
                    float3 lowerVert = new float3
                    {
                        x = (float)(radius * Math.Cos(i * deltaSegmentAngle)),
                        y = -height / 2,
                        z = (float)(radius * Math.Sin(i * deltaSegmentAngle))
                    };
                    //bottom verts with radial normal
                    verts[(4 * i) + 2] = lowerVert;
                    norms[(4 * i) + 2] = radialNormal;

                    //bottom verts with bottom normal
                    verts[(4 * i) + 3] = lowerVert;
                    norms[(4 * i) + 3] = new float3(0, -1, 0);
                }

                //Create tris
                if (i > 0)
                {
                    //top triangle
                    tris[12 * (i - 1) + 0] = (ushort)(4 * segmentsAmount);       // top center point
                    tris[12 * (i - 1) + 1] = (ushort)(4 * (i - 1));      // current top segment point
                    tris[12 * (i - 1) + 2] = (ushort)(4 * i);      // previous top segment point

                    // side triangle 1
                    tris[12 * (i - 1) + 3] = (ushort)(4 * (i - 1) + 2);      // previous lower shell point
                    tris[12 * (i - 1) + 4] = (ushort)(4 * i + 2);      // current lower shell point
                    tris[12 * (i - 1) + 5] = (ushort)(4 * i + 1);      // current top shell point

                    // side triangle 2
                    tris[12 * (i - 1) + 6] = (ushort)(4 * (i - 1) + 2);      // previous lower shell point
                    tris[12 * (i - 1) + 7] = (ushort)(4 * i + 1);      // current top shell point
                    tris[12 * (i - 1) + 8] = (ushort)(4 * (i - 1) + 1);      // previous top shell point

                    // bottom triangle
                    tris[12 * (i - 1) + 9] = (ushort)(4 * segmentsAmount + 1);    // bottom center point
                    tris[12 * (i - 1) + 10] = (ushort)(4 * i + 3);     // current bottom segment point
                    tris[12 * (i - 1) + 11] = (ushort)(4 * (i - 1) + 3);     // previous bottom segment point
                }
            }

            //final tris
            //top triangle
            tris[12 * (segmentsAmount - 1) + 0] = (ushort)(4 * segmentsAmount);       // top center point
            tris[12 * (segmentsAmount - 1) + 1] = (ushort)(4 * (segmentsAmount - 1));      // current top segment point
            tris[12 * (segmentsAmount - 1) + 2] = (ushort)0;      // previous top segment point

            // side triangle 1
            tris[12 * (segmentsAmount - 1) + 3] = (ushort)(4 * (segmentsAmount - 1) + 2);      // previous lower shell point
            tris[12 * (segmentsAmount - 1) + 4] = (ushort)2;      // current lower shell point
            tris[12 * (segmentsAmount - 1) + 5] = (ushort)1;      // current top shell point

            // side triangle 2
            tris[12 * (segmentsAmount - 1) + 6] = (ushort)(4 * (segmentsAmount - 1) + 2);      // previous lower shell point
            tris[12 * (segmentsAmount - 1) + 7] = (ushort)1;      // current top shell point
            tris[12 * (segmentsAmount - 1) + 8] = (ushort)(4 * (segmentsAmount - 1) + 1);      // previous top shell point

            // bottom triangle
            tris[12 * (segmentsAmount - 1) + 9] = (ushort)(4 * segmentsAmount + 1);    // bottom center point
            tris[12 * (segmentsAmount - 1) + 10] = (ushort)3;     // current bottom segment point
            tris[12 * (segmentsAmount - 1) + 11] = (ushort)(4 * (segmentsAmount - 1) + 3);     // previous bottom segment point

            return new Mesh
            {
                Vertices = verts,
                Triangles = tris,
                Normals = norms
            };
        }

        private static void setValuesIntoTrisArray(ushort[] trisArray, int triStartIndex, ushort value1, ushort value2, ushort value3)
        {
            trisArray[triStartIndex - 1] = value1;
            trisArray[triStartIndex - 2] = value2;
            trisArray[triStartIndex - 3] = value3;
        }

        public static Mesh CreateCone(float radius, float height, int segments)
        {
            return CreateConeFrustum(radius, 0.0f, height, segments);
        }

        public static Mesh CreateConeFrustum(float radiuslower, float radiusupper, float height, int segments)
        {
            throw new NotImplementedException();
        }


        public static Mesh CreatePyramid(float baselen, float height)
        {
            throw new NotImplementedException();
        }
        public static Mesh CreateTetrahedron(float edgelen)
        {
            throw new NotImplementedException();
        }

        public static Mesh CreateTorus(float mainradius, float segradius, int segments, int slices)
        {
            throw new NotImplementedException();
        }

    }
}
